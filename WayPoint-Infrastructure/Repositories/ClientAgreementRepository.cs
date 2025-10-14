using System.Collections.ObjectModel;
using WayPoint.Model;
using WayPoint.Model.Templated;
using WayPoint.Model.ViewModels;
using WayPoint_Infrastructure.Data;
using WayPoint_Infrastructure.Helpers;
using WayPoint_Infrastructure.Interfaces;

namespace WayPoint_Infrastructure.Repositories
{
    public class ClientAgreementRepository(ISqlEngine sql, IEfReadEngine<WayPointDbContext> ef, ILookUpRepository LookupRepo) : IClientAgreementRepository
    {
        private readonly ISqlEngine _sql = sql ?? throw new ArgumentNullException(nameof(sql));
        private readonly IEfReadEngine<WayPointDbContext> _ef = ef;
        private readonly ILookUpRepository _lookupRepo = LookupRepo;

        public async Task<bool> SaveEntityProducts(List<WorkOrderClientAgreementEntityProduct> workOrderClientAgreementEntityProducts, int workOrderId, int systemDiscountScheduleId, CancellationToken ct = default)
        {
            try
            {
                var workOrderClientAgreement = await _sql.RetrieveObjectAsync<WorkOrderClientAgreement>(
                new { WorkOrderId = workOrderId },
                ct);
                var now = DateTime.UtcNow;


                workOrderClientAgreement.SystemDiscountScheduleId = systemDiscountScheduleId;
                workOrderClientAgreement.LastUpdateDate = now;
                workOrderClientAgreement.LastUpdatedBy = "dmeka";

                var existingProducts = await _ef.RetrieveAsync<WorkOrderClientAgreementEntityProduct>(
                    e => e.WorkOrderClientAgreementId == workOrderClientAgreement.WorkOrderClientAgreementId,
                    ct: ct);

                var products = existingProducts.Where(x => !x.Removed && !x.IsAdditionalDiscount).ToList();

                products
                    .ForEach(x =>
                    {
                        x.Removed = true;
                        x.LastUpdatedBy = "dmeka";
                        x.LastUpdateDate = DateTime.UtcNow;
                    });

                await _ef.SaveEntities(products,
                    useTransaction: false, ct: ct, bulkOperation: null);

                foreach (var e in workOrderClientAgreementEntityProducts)
                {
                    e.WorkOrderClientAgreementId = workOrderClientAgreement.WorkOrderClientAgreementId;
                    e.LastUpdateDate = now;
                    e.LastUpdatedBy = "dmeka";
                    if (e.WorkOrderClientAgreementEntityProductId == 0)
                    {
                        e.CreationDate = now;
                        e.CreatedBy = "dmeka";
                    }
                }

                ModelHelper.UpdateModelState(workOrderClientAgreement, ObjectState.Modified, "dmeka", DateTime.Now); ;

                await _sql.SaveEntityAsync(workOrderClientAgreement, ct: ct);

                await _ef.SaveEntities(workOrderClientAgreementEntityProducts,
                    useTransaction: false, ct: ct, bulkOperation: null);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IReadOnlyList<WorkOrderClientAgreementEntityProduct>> GetWorkOrderClientAgreementEntityProducts(int workOrderId, CancellationToken ct = default)
        {
            var workOrderClientAgreement = await _sql.RetrieveObjectAsync<WorkOrderClientAgreement>(new { workOrderId }, ct);
            var queryable = await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntityProduct>(
                new { workOrderClientAgreement.WorkOrderClientAgreementId },
                ct
            );

            var list = queryable
                        .Where(x => x.IsAdditionalDiscount == false
                        && x.WorkOrderClientAgreementEntityId == null)
                        .OrderBy(m => m.TonnageBilling)
                        .ThenBy(m => m.DefaultOrder)
                        .ToList();

            return new ReadOnlyCollection<WorkOrderClientAgreementEntityProduct>(list);
        }

        public async Task<WorkOrderClientAgreement> GetWorkOrderClientAgreement(int workOrderId, CancellationToken ct = default)
        {
            return await _sql.RetrieveObjectAsync<WorkOrderClientAgreement>(new { workOrderId }, ct);
        }

        public async Task<IReadOnlyList<WorkOrderClientAgreementEntityProduct>> GetAdditionalDiscountedProducts(int workOrderId, CancellationToken ct = default)
        {
            var workOrderClientAgreement = await _sql.RetrieveObjectAsync<WorkOrderClientAgreement>(new { workOrderId }, ct);
            var queryable = await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntityProduct>(
                new { workOrderClientAgreement.WorkOrderClientAgreementId },
                ct
            );

            var list = queryable
                        .Where(x => x.IsAdditionalDiscount == true
                        && x.WorkOrderClientAgreementEntityId == null)
                        .OrderByDescending(a => a.Amount)
                        .ToList();

            return new ReadOnlyCollection<WorkOrderClientAgreementEntityProduct>(list);
        }

        public async Task<bool> UpdateEntityProduct(WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default)
        {
            try
            {
                var agreementEntityProduct = await _sql.RetrieveObjectAsync<WorkOrderClientAgreementEntityProduct>(new { workOrderClientAgreementEntityProduct.WorkOrderClientAgreementEntityProductId }, ct);
                if (agreementEntityProduct == null || agreementEntityProduct.WorkOrderClientAgreementEntityProductId == 0)
                    return false;

                agreementEntityProduct.SystemProductId = workOrderClientAgreementEntityProduct.SystemProductId;
                agreementEntityProduct.DiscountType = workOrderClientAgreementEntityProduct.DiscountType;
                agreementEntityProduct.Amount = workOrderClientAgreementEntityProduct.Amount;
                agreementEntityProduct.LimitPerYear = workOrderClientAgreementEntityProduct.LimitPerYear;
                agreementEntityProduct.ExpiryDate = workOrderClientAgreementEntityProduct.ExpiryDate;
                agreementEntityProduct.LastUpdatedBy = "dmeka";
                agreementEntityProduct.LastUpdateDate = DateTime.Now;


                await _ef.SaveEntity(agreementEntityProduct,
                    ct: ct);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> RemoveEntityProduct(int workOrderClientAgreementEntityProductId, CancellationToken ct = default)
        {
            try
            {
                var agreementEntityProduct = await _sql.RetrieveObjectAsync<WorkOrderClientAgreementEntityProduct>(new { workOrderClientAgreementEntityProductId }, ct);
                if (agreementEntityProduct == null || agreementEntityProduct.WorkOrderClientAgreementEntityProductId == 0)
                    return false;

                agreementEntityProduct.LastUpdatedBy = "dmeka";
                agreementEntityProduct.LastUpdateDate = DateTime.Now;
                agreementEntityProduct.Removed = true;
                await _ef.SaveEntity(agreementEntityProduct,
                    ct: ct);
                return true;
            }
            catch (Exception ex) { return false; }

        }
        public async Task<bool> RemoveEntityProducts(int[] ids, CancellationToken ct = default)
        {
            if (ids == null) return false;
            var idList = ids.Where(i => i > 0).Distinct().ToArray();
            if (idList.Length == 0) return false;

            var existingList = await _ef.RetrieveAsync<WorkOrderClientAgreementEntityProduct>(
                e => idList.Contains(e.WorkOrderClientAgreementEntityProductId), ct: ct);

            if (existingList == null || !existingList.Any())
                return false;

            existingList.ForEach(x =>
            {
                x.Removed = true;
                x.LastUpdatedBy = "dmeka";
                x.LastUpdateDate = DateTime.UtcNow;
            });

            await _ef.SaveEntities(existingList,
                    ct: ct);
            return true;

        }
        public async Task<bool> SaveWorkOrderClientAgreementProduct(WorkOrderClientAgreementEntityProduct workOrderClientAgreementEntityProduct, CancellationToken ct = default)
        {
            try
            {
                var queryable = await _sql.RetrieveObjectsAsync<SystemProductDiscountGroup>(
                new { ProductGroup = workOrderClientAgreementEntityProduct.ProductGroupTypeId },
                ct);

                if (queryable == null || queryable.Count == 0) return false;

                var entityProducts = queryable.Select(obj => new WorkOrderClientAgreementEntityProduct
                {
                    SystemProductId = obj.SystemProductId,
                    Amount = null,
                    IsAdditionalDiscount = true,
                    WorkOrderClientAgreementId = workOrderClientAgreementEntityProduct.WorkOrderClientAgreementId,
                    DiscountType = null,
                    CreatedBy = "dmeka",
                    CreationDate = DateTime.Now,
                    LastUpdatedBy = "dmeka",
                    LastUpdateDate = DateTime.Now
                }).ToList();
                await _ef.SaveEntities(entityProducts, ct: ct);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> SaveWorkOrderClientAgreementEntityByEntityId(WorkOrderClientAgreementEntity workOrderClientAgreementEntity, int woClientAgreementId, int workOrderId, bool hasAdditionalDiscounts, CancellationToken ct = default)
        {
            workOrderClientAgreementEntity.WorkOrderVesselId = await CreateWorkOrderVesselData(workOrderClientAgreementEntity.EntityId, workOrderId, ct);
            var retWorkOrderClientAgreementEntity = await SaveWorkOrderClientAgreementEntityById(workOrderClientAgreementEntity, woClientAgreementId, ct);
            if (hasAdditionalDiscounts)
                await AddWOClientAgreementEntitiesAdditionalDiscounts(retWorkOrderClientAgreementEntity, ct);
            return true;
        }
        public async Task<int> CreateWorkOrderVesselData(int entityId, int workOrderId, CancellationToken ct = default)
        {
            Vessel vessel = await _sql.RetrieveObjectAsync<Vessel>(new { EntityId = entityId }, ct);

            if (vessel == null)
                throw new InvalidOperationException($"No vessel found");

            var vesselClients = (await _sql.RetrieveObjectsAsync<VesselClient>(
                new { VesselId = vessel.VesselId }, ct))
                .Where(vc => vc.ToDate == null)
                .ToList();

            var vesselViewModel = new VesselViewModel
            {
                vessel = vessel,
                lVesselClient = vesselClients
            };

            return await AddWorkOrderEntity(workOrderId, vesselViewModel, isChild: true, ct);
        }
        public async Task<int> AddWorkOrderEntity(int workOrderId, VesselViewModel vesselViewModel, bool isChild, CancellationToken ct = default)
        {
            WorkOrderVessel newWorkOrderVessel = new WorkOrderVessel();
            if (vesselViewModel != null)
            {
                WorkOrderEntity workOrderEntity = new WorkOrderEntity()
                {
                    WorkOrderId = workOrderId,
                    EntityId = Convert.ToInt32(vesselViewModel.vessel.EntityId),
                    IsChild = isChild
                };
                ModelHelper.UpdateModelState(workOrderEntity, ObjectState.New, "vjonnadula", DateTime.Now);
                workOrderEntity = await _ef.SaveEntity(workOrderEntity, ct: ct);
                newWorkOrderVessel = await AddWorkOrderVessel(vesselViewModel, workOrderEntity);
                await AddWorkOrderVesselClient(vesselViewModel, newWorkOrderVessel);
            }
            return newWorkOrderVessel.WorkOrderVesselId;
        }
        public async Task<WorkOrderVessel> AddWorkOrderVessel(VesselViewModel vesselViewModel, WorkOrderEntity workOrderEntity)
        {
            WorkOrderVessel newWorkOrderVessel = vesselViewModel.vessel.GetWorkOrderVessel();
            newWorkOrderVessel.WorkOrderEntityId = workOrderEntity.WorkOrderEntityId;
            if (newWorkOrderVessel.VesselTypeId == -1)
                newWorkOrderVessel.VesselTypeId = 0;

            ModelHelper.UpdateModelState(newWorkOrderVessel, ObjectState.New, "vjonnadula", DateTime.Now);
            newWorkOrderVessel = await _ef.SaveEntity(newWorkOrderVessel);
            return newWorkOrderVessel;
        }
        public async Task<bool> AddWorkOrderVesselClient(VesselViewModel vesselViewModel, WorkOrderVessel workOrderVessel)
        {
            var workOrderVesselClients = new List<WorkOrderVesselClient>();
            vesselViewModel.lVesselClient.ForEach(vesselClient =>
            {
                var workOrderVesselClient = vesselClient.GetWorkOrderVesselClient();
                workOrderVesselClient.WorkOrderVesselId = workOrderVessel.WorkOrderVesselId;
                if (workOrderVesselClient.WorkOrderVesselClientId == 0)
                {
                    workOrderVesselClient.CreationDate = DateTime.UtcNow;
                    workOrderVesselClient.CreatedBy = "vjonnadula";
                }
                workOrderVesselClient.LastUpdateDate = DateTime.UtcNow;
                workOrderVesselClient.LastUpdatedBy = "vjonnadula";
                ModelHelper.UpdateModelState(workOrderVesselClient, ObjectState.New, "vjonnadula", DateTime.UtcNow);
            });
            await _ef.SaveEntities(workOrderVesselClients, useTransaction: false, bulkOperation: null);
            return true;
        }
        public async Task<WorkOrderClientAgreementEntity> SaveWorkOrderClientAgreementEntityById(WorkOrderClientAgreementEntity woclientAgreementEntity, int woClientAgreementId, CancellationToken ct = default)
        {
            var _WOclientAgreementEntity = await _sql.RetrieveObjectAsync<WorkOrderClientAgreementEntity>(
                new { WorkOrderClientAgreementId = woClientAgreementId, EntityId = woclientAgreementEntity.EntityId }, ct);

            if (_WOclientAgreementEntity != null && _WOclientAgreementEntity.WorkOrderClientAgreementEntityId > 0)
            {
                // Update existing entity
                _WOclientAgreementEntity.WorkOrderItemEntityId = woclientAgreementEntity.WorkOrderItemEntityId;
                _WOclientAgreementEntity.ClientId = woclientAgreementEntity.ClientId;
                _WOclientAgreementEntity.WorkOrderClientAgreementId = woclientAgreementEntity.WorkOrderClientAgreementId;
                _WOclientAgreementEntity.EntityId = woclientAgreementEntity.EntityId;
                _WOclientAgreementEntity.SystemDiscountScheduleId = woclientAgreementEntity.SystemDiscountScheduleId;
                _WOclientAgreementEntity.EnrollmentDate = woclientAgreementEntity.EnrollmentDate;
                _WOclientAgreementEntity.AnniversaryDate = woclientAgreementEntity.AnniversaryDate;
                _WOclientAgreementEntity.IsCustomFees = woclientAgreementEntity.IsCustomFees;
                _WOclientAgreementEntity.BillToClient = woclientAgreementEntity.BillToClient;
                _WOclientAgreementEntity.BillingCycle = woclientAgreementEntity.BillingCycle;
                _WOclientAgreementEntity.BillingCycleCounter = await (woclientAgreementEntity.BillingCycle.HasValue ? GetBillingCycleLegacyValue(woclientAgreementEntity.BillingCycle.Value) : null); ;
                _WOclientAgreementEntity.NoJoiningInvoice = woclientAgreementEntity.NoJoiningInvoice;

                ModelHelper.UpdateModelState(_WOclientAgreementEntity, ObjectState.Modified, "vjonnadula", DateTime.Now);
            }
            else
            {
                _WOclientAgreementEntity = woclientAgreementEntity;
                _WOclientAgreementEntity.BillingCycleCounter = await (woclientAgreementEntity.BillingCycle.HasValue ? GetBillingCycleLegacyValue(woclientAgreementEntity.BillingCycle.Value) : null);
                ModelHelper.UpdateModelState(_WOclientAgreementEntity, ObjectState.New, "vjonnadula", DateTime.Now);
            }
            var retWOClientAgreementEntity = await _ef.SaveEntity(_WOclientAgreementEntity, ct: ct);

            retWOClientAgreementEntity.EntityId = retWOClientAgreementEntity.EntityId > 0 ? retWOClientAgreementEntity.EntityId : woclientAgreementEntity.EntityId;
            await SaveWorkOrderClientAgreementEntityProductsForEntity(retWOClientAgreementEntity, woClientAgreementId, ct);

            return retWOClientAgreementEntity;
        }
        public async Task<int?> GetBillingCycleLegacyValue(int LookupId)
        {
            List<Lookup> lBillingCycleLookup = (await _lookupRepo.GetLookupsByTypeName(ApplicationConstants.BILLING_CYCLE_YEAR)).ToList();
            var Lookup = lBillingCycleLookup.Where(x => x.LookupId == LookupId).FirstOrDefault();
            return int.TryParse(Lookup?.LegacyValue, out int legacyValue) ? legacyValue : null;
        }
        public async Task<bool> SaveWorkOrderClientAgreementEntityProductsForEntity(WorkOrderClientAgreementEntity retWOClientAgreementEntity, int woClientAgreementId, CancellationToken ct = default)
        {
            List<WorkOrderClientAgreementEntityProduct> retProducts = new List<WorkOrderClientAgreementEntityProduct>();
            List<WorkOrderClientAgreementEntityProduct> lWorkOrderClientAgreementEntityProducts = (await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntityProduct>(new { WorkOrderClientAgreementId = woClientAgreementId }, ct)).Where(x => x.IsAdditionalDiscount == false && x.WorkOrderClientAgreementEntityId == null).OrderBy(m => m.TonnageBilling).ThenBy(m => m.DefaultOrder).ToList();
            if (lWorkOrderClientAgreementEntityProducts.Count == 0) return true;

            WorkOrderClientAgreement woClientAgreement = await _sql.RetrieveObjectAsync<WorkOrderClientAgreement>(new { WorkOrderClientAgreementId = woClientAgreementId }, ct);
            Vessel vessel = await _sql.RetrieveObjectAsync<Vessel>(new { EntityId = retWOClientAgreementEntity.EntityId }, ct);
            if (vessel == null)
                throw new InvalidOperationException($"Vessel not found");

            string woName = woClientAgreement?.SystemWorkOrderName ?? string.Empty;
            int registrationYear = vessel.RegistrationDate?.Year ?? DateTime.Now.Year;

            List<WorkOrderClientAgreementEntityProduct> existingProducts = (await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntityProduct>(new { WorkOrderClientAgreementEntityId = retWOClientAgreementEntity.WorkOrderClientAgreementEntityId }, ct)).Where(x => !x.IsAdditionalDiscount).ToList();
            if (existingProducts.Any())
                return true;
            List<WorkOrderClientAgreementEntityProduct> productsToAdd = new List<WorkOrderClientAgreementEntityProduct>();

            foreach (var WorkOrderClientAgreementEntityProduct in lWorkOrderClientAgreementEntityProducts)
            {
                var (startDate, endDate) = CalculateProductPeriod(WorkOrderClientAgreementEntityProduct, vessel, woName, registrationYear);
                productsToAdd.Add(new WorkOrderClientAgreementEntityProduct()
                {
                    SystemProductId = WorkOrderClientAgreementEntityProduct.SystemProductId,
                    SystemProductName = WorkOrderClientAgreementEntityProduct.SystemProductName,
                    SystemProductAmount = WorkOrderClientAgreementEntityProduct.SystemProductAmount,
                    DefaultOrder = WorkOrderClientAgreementEntityProduct.DefaultOrder,
                    DiscountType = WorkOrderClientAgreementEntityProduct.DiscountType,
                    DiscountTypeName = WorkOrderClientAgreementEntityProduct.DiscountTypeName,
                    Amount = WorkOrderClientAgreementEntityProduct.Amount,
                    TonnageBilling = WorkOrderClientAgreementEntityProduct.TonnageBilling,
                    IsOngoingDiscount = WorkOrderClientAgreementEntityProduct.IsOngoingDiscount,
                    WorkOrderClientAgreementEntityId = retWOClientAgreementEntity.WorkOrderClientAgreementEntityId,
                    WorkOrderClientAgreementId = woClientAgreementId,
                    StartDate = startDate,
                    ExpiryDate = endDate
                });
            }
            productsToAdd.ForEach((a) => ModelHelper.UpdateModelState(a, ObjectState.New, "vjonnadula", DateTime.Now));
            retProducts.AddRange(productsToAdd);

            if (retProducts.Count > 0)
                await _ef.SaveEntities<WorkOrderClientAgreementEntityProduct>(retProducts);
            return true;
        }
        private static (DateTime? startDate, DateTime? endDate) CalculateProductPeriod(WorkOrderClientAgreementEntityProduct product, Vessel vessel, string workOrderName, int registrationYear)
        {
            if (string.IsNullOrEmpty(workOrderName))
                return (null, null);

            DateTime startDate = product.TonnageBilling == 1
                ? vessel.RegistrationDate ?? DateTime.Now
                : new DateTime(registrationYear + (int)(product.TonnageBilling - 1), 1, 1);

            DateTime? endDate = product.IsOngoingDiscount ? null : new DateTime(startDate.Year, 12, 31);

            return (startDate, endDate);
        }
        public async Task<bool> AddWOClientAgreementEntitiesAdditionalDiscounts(WorkOrderClientAgreementEntity savedWOCAEntity, CancellationToken ct = default)
        {
            var woCAEntityAdditinalDiscountEntities = (await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntityProduct>(new { WorkOrderClientAgreementId = savedWOCAEntity.WorkOrderClientAgreementId, WorkOrderClientAgreementEntityId = savedWOCAEntity.WorkOrderClientAgreementEntityId }, ct)).Where(x => x.IsAdditionalDiscount == true).ToList();
            if (woCAEntityAdditinalDiscountEntities.Any())
                return true;
            var currentCAAdditionalDiscounts = (await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntityProduct>(
                new { WorkOrderClientAgreementId = savedWOCAEntity.WorkOrderClientAgreementId }, ct)).Where(x => x.IsAdditionalDiscount && x.WorkOrderClientAgreementEntityId == null).ToList();
            if (currentCAAdditionalDiscounts.Any())
            {
                var lsavedWOCAEntity = new List<WorkOrderClientAgreementEntity> { savedWOCAEntity };
                await AddAdditionalDiscountsToClientAgreementEntities(currentCAAdditionalDiscounts, lsavedWOCAEntity, ct);
            }

            return true;
        }
        public async Task<bool> AddAdditionalDiscountsToClientAgreementEntities(List<WorkOrderClientAgreementEntityProduct> woClientAgreementAdditionalDiscounts, List<WorkOrderClientAgreementEntity> woClientAgreementEntities, CancellationToken ct = default)
        {
            var woClientAgrreementProductsForEntites = new List<WorkOrderClientAgreementEntityProduct>();
            foreach (var entity in woClientAgreementEntities)
            {
                var toBeupdateAdditionalDiscounts = new List<WorkOrderClientAgreementEntityProduct>();

                foreach (var discount in woClientAgreementAdditionalDiscounts)
                {
                    var mapped = await RetrieveAndMapProps(discount, entity.WorkOrderClientAgreementEntityId);
                    mapped.WorkOrderClientAgreementEntityProductId = -1;
                    toBeupdateAdditionalDiscounts.Add(mapped);
                }

                woClientAgrreementProductsForEntites.AddRange(toBeupdateAdditionalDiscounts);
            }
            if (woClientAgrreementProductsForEntites.Any())
            {
                foreach (var product in woClientAgrreementProductsForEntites)
                    ModelHelper.UpdateModelState(product, ObjectState.New, "vjonnadula", DateTime.Now);

                await _ef.SaveEntities<WorkOrderClientAgreementEntityProduct>(woClientAgrreementProductsForEntites);
            }

            return true;
        }
        private async Task<WorkOrderClientAgreementEntityProduct> RetrieveAndMapProps(WorkOrderClientAgreementEntityProduct woClientAgreementProduct, int WorkOrderClientAgreementEntityId)
        {
            WorkOrderClientAgreementEntityProduct objWOClientAgreementEntityProduct = new WorkOrderClientAgreementEntityProduct();
            objWOClientAgreementEntityProduct.WorkOrderClientAgreementEntityId = WorkOrderClientAgreementEntityId;
            objWOClientAgreementEntityProduct.WorkOrderClientAgreementId = woClientAgreementProduct.WorkOrderClientAgreementId;
            objWOClientAgreementEntityProduct.SystemProductId = woClientAgreementProduct.SystemProductId;
            objWOClientAgreementEntityProduct.DiscountType = woClientAgreementProduct.DiscountType;
            objWOClientAgreementEntityProduct.Amount = woClientAgreementProduct.Amount;
            objWOClientAgreementEntityProduct.IsAdditionalDiscount = woClientAgreementProduct.IsAdditionalDiscount;
            objWOClientAgreementEntityProduct.LimitPerYear = woClientAgreementProduct.LimitPerYear;
            objWOClientAgreementEntityProduct.ExpiryDate = woClientAgreementProduct.ExpiryDate;
            objWOClientAgreementEntityProduct.DefaultOrder = woClientAgreementProduct.DefaultOrder;

            return objWOClientAgreementEntityProduct;
        }
        public async Task<bool> SaveWorkOrderClientAgreementVesselEntities(WorkOrderClientAgreementViewModel workOrderClientAgreementViewModel, CancellationToken ct = default)
        {
            try
            {
                var selectedEntities = workOrderClientAgreementViewModel.lWorkOrderClientAgreementEntity?.Where(x => x.IsSelected).ToList();

                if (selectedEntities == null || !selectedEntities.Any() || workOrderClientAgreementViewModel.WorkOrderClientAgreement.WorkOrderClientAgreementId <= 0)
                {
                    return false;
                }

                // Retrieve WorkOrderClientAgreement
                var agreement = await _sql.RetrieveObjectAsync<WorkOrderClientAgreement>(
                    new { workOrderClientAgreementViewModel.WorkOrderClientAgreement.WorkOrderClientAgreementId }, ct);

                if (agreement == null)
                    return false;

                // Update consolidated statement
                agreement.ConsolidatedStatement = workOrderClientAgreementViewModel.WorkOrderClientAgreement.ConsolidatedStatement;
                await _ef.SaveEntity(agreement, ct);

                // Retrieve existing entities for comparison
                var existingEntities = await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntity>(
                    new { workOrderClientAgreementViewModel.WorkOrderClientAgreement.WorkOrderClientAgreementId }, ct);

                // Save new/updated entities
                workOrderClientAgreementViewModel.lWorkOrderClientAgreementEntity = await SaveEntitiesAndProducts(selectedEntities, existingEntities, workOrderClientAgreementViewModel.WorkOrderClientAgreement.WorkOrderClientAgreementId, workOrderClientAgreementViewModel.WorkOrderId, ct);

                // Update Original Anniversary Year if not ADA
                if (workOrderClientAgreementViewModel.WorkOrderClientAgreement.SystemDiscountProgramName != ApplicationConstants.DISCOUNT_PROGRAM_ADA)
                {
                    await UpdateOriginalAnniversaryYear(agreement, workOrderClientAgreementViewModel.lWorkOrderClientAgreementEntity, ct);
                }

                // Ensure Appendix 1 document exists
                var insertedDocs = (await _sql.RetrieveObjectsAsync<WorkOrderDocument>(
                    new { workOrderClientAgreementViewModel.WorkOrderId }, ct)).ToList();

                bool appendix1Exists = insertedDocs.Any(d => d.Name == ApplicationConstants.WORKORDER_DOCUMENT_APPENDIX1);

                if (!appendix1Exists)
                {
                    await EnsureAppendix1DocumentExists(workOrderClientAgreementViewModel.WorkOrderId, ct);
                }
                //if (workOrderClientAgreementViewModel.WorkOrderClientAgreement.SystemDiscountProgramName != ApplicationConstants.DISCOUNT_PROGRAM_ADA)
                //{
                //    string HangfireConnectionString = ConfigurationManager.ConnectionStrings["HangFireStorage"].ToString();
                //    JobStorage.Current = new SqlServerStorage(HangfireConnectionString);
                //    WorkOrder workOrder = await _sql.RetrieveObjectAsync<WorkOrder>(new { WorkOrderId = workOrderClientAgreementViewModel.WorkOrderId },ct);
                //    BackgroundJob.Schedule(() => SaveBFAWorkOrderInvoiceFromHangfire(workOrderClientAgreementViewModel.WorkOrderId, _userName), TimeSpan.FromSeconds(1));
                //}
                // Generate Appendix 1 document
                var docsToGenerate = new List<string> { ApplicationConstants.WORKORDER_DOCUMENT_APPENDIX1 };
                await GenerateClientAgreementDocuments(workOrderClientAgreementViewModel.WorkOrderId, docsToGenerate, ct);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private async Task EnsureAppendix1DocumentExists(int workOrderId, CancellationToken ct)
        {
            var workOrder = await _sql.RetrieveObjectAsync<WorkOrder>(new { WorkOrderId = workOrderId }, ct);
            if (workOrder == null) return;

            var systemDocs = await _sql.RetrieveObjectsAsync<SystemWorkOrderDocument>(
                new { workOrder.SystemWorkOrderId }, ct);

            var appendix1Doc = systemDocs.FirstOrDefault(d => d.Name == ApplicationConstants.WORKORDER_DOCUMENT_APPENDIX1);
            if (appendix1Doc == null) return;

            var workOrderItems = await _sql.RetrieveObjectsAsync<WorkOrderItemEntity>(
                new { WorkOrderId = workOrderId }, ct);

            var itemEntity = workOrderItems.FirstOrDefault(a => a.SystemWorkOrderItemName == workOrder.DisplayName);
            if (itemEntity == null) return;

            await CreateWorkOrderDocument(appendix1Doc.SystemDocumentId, itemEntity.WorkOrderItemEntityId, ct);
        }
        public async Task<List<WorkOrderClientAgreementEntity>> SaveEntitiesAndProducts(List<WorkOrderClientAgreementEntity> lCurrentWOClientAgreementEntity, IReadOnlyList<WorkOrderClientAgreementEntity> lExistingWOClientAgreementEntity, int woClientAgreementId, int workOrderId, CancellationToken ct = default)
        {
            var removeEntities = lExistingWOClientAgreementEntity.Where(w => !lCurrentWOClientAgreementEntity.Any(p => p.EntityId == w.EntityId)).ToList();
            List<WorkOrderClientAgreementEntity> retlWOClientAgreementEntity = new();
            if (removeEntities != null && removeEntities.Count > 0)
            {
                List<int> lWorkOrderVesselId = new List<int>();
                lWorkOrderVesselId.AddRange(removeEntities.Select(x => x.WorkOrderVesselId.Value));
                string workOrderVesselIdList = string.Join(",", lWorkOrderVesselId);
                await RemoveWorkOrderVesselClients(workOrderVesselIdList, ct);
                await RemoveWorkOrderVessel(workOrderVesselIdList, ct);
                List<int> lWorkOrderItemEntityId = new List<int>();
                lWorkOrderItemEntityId.AddRange(removeEntities.Where(x => x.WorkOrderItemEntityId != null).Select(x => x.WorkOrderItemEntityId.Value));
                string workOrderItemEntityIdList = string.Join(",", lWorkOrderItemEntityId);
                if (!string.IsNullOrEmpty(workOrderItemEntityIdList))
                {
                    //remove workorderdocument
                    await RemoveWorkOrderDocuments(workOrderItemEntityIdList);

                    //remove invoice related items i.e. WOInvoiceItems and  WOInvoice
                    await RemoveInvoiceItems(workOrderItemEntityIdList);

                    //remove workorderitementity
                    await RemoveWorkOrderItemEntities(workOrderItemEntityIdList);
                }
                List<int> lEntityId = new List<int>();
                lEntityId.AddRange(removeEntities.Select(x => x.EntityId));
                string entityIdList = string.Join(",", lEntityId);
                await RemoveWorkOrderEntity(workOrderId, entityIdList);
                await RemoveWOClientAgreementEntityProducts(removeEntities);
                await RemoveWorkOrderClientAgreementEntities(removeEntities);
            }

            var savedWOCAEntities = await GetWOClientAgreementEntitiesByWOClientAgreementId(woClientAgreementId);
            List<WorkOrderClientAgreementEntity> invoiceTobeCreatedWOCAEntities = savedWOCAEntities.Where(x => x.NoJoiningInvoice == false).ToList();
            if (invoiceTobeCreatedWOCAEntities == null || invoiceTobeCreatedWOCAEntities.Any()) return new List<WorkOrderClientAgreementEntity>();

            WorkOrder wo = await _sql.RetrieveObjectAsync<WorkOrder>(new { WorkOrderId = workOrderId }, ct);
            if (wo.DisplayName == ApplicationConstants.AMEND_BFA_WORKORDER)
            {
                var clientAgreement = await _sql.RetrieveObjectAsync<ClientAgreements>(new { ClientId = wo.ClientId, SystemDiscountProgramName = ApplicationConstants.DISCOUNT_PROGRAM_BFA }, ct);
                if (clientAgreement != null && (clientAgreement.ClientAgreementStatusName == ApplicationConstants.ACTIVE || clientAgreement.ClientAgreementStatusName == ApplicationConstants.SIGNED_AND_RECEIVED))
                {
                    var prevClientAgrEntities = await _sql.RetrieveObjectsAsync<ClientAgreementEntities>(
                        new { ClientAgreementId = clientAgreement.ClientAgreementId }, ct);

                    var validPrevEntities = prevClientAgrEntities
                        .Where(x => x.EntityTypeName == ApplicationConstants.VESSEL && !x.NoJoiningInvoice)
                        .ToList();

                    invoiceTobeCreatedWOCAEntities = invoiceTobeCreatedWOCAEntities
                        .Where(x => !validPrevEntities.Select(y => y.EntityId).Contains(x.EntityId))
                        .ToList();
                }
                await CreateWorkOrderItemEntities(invoiceTobeCreatedWOCAEntities, workOrderId, ct);
                List<WorkOrderClientAgreementEntity> tobeRemovedWOCAEntities = savedWOCAEntities.Where(x => x.NoJoiningInvoice == true).ToList();
                if (tobeRemovedWOCAEntities != null && tobeRemovedWOCAEntities.Count > 0)
                {
                    // build workOrderItemEntityIdList which have values from WorkOrderClientAgreementEntities that need to be removed
                    List<int> lWorkOrderItemEntityId = new List<int>();
                    lWorkOrderItemEntityId.AddRange(tobeRemovedWOCAEntities.Where(x => x.WorkOrderItemEntityId != null).Select(x => x.WorkOrderItemEntityId.Value));
                    string workOrderItemEntityIdList = string.Join(",", lWorkOrderItemEntityId);

                    if (!string.IsNullOrEmpty(workOrderItemEntityIdList))
                    {
                        //remove workorderdocument
                        await RemoveWorkOrderDocuments(workOrderItemEntityIdList);

                        //remove invoice related items i.e. WOInvoiceItems and  WOInvoice
                        await RemoveInvoiceItems(workOrderItemEntityIdList);

                        //remove workorderitementity
                        await RemoveWorkOrderItemEntities(workOrderItemEntityIdList);
                    }
                    //set WorkOrderItemEntityId as null to the records which has NoJoiningInvoice set to true
                    tobeRemovedWOCAEntities.ForEach(a => a.WorkOrderItemEntityId = null);
                    tobeRemovedWOCAEntities.ForEach((a) => ModelHelper.UpdateModelState(a, ObjectState.Modified, "vjonnadula", DateTime.Now));
                    await _ef.SaveEntities<WorkOrderClientAgreementEntity>(tobeRemovedWOCAEntities);
                }

                retlWOClientAgreementEntity = await GetWOClientAgreementEntitiesByWOClientAgreementId(woClientAgreementId, ct);
            }
            return retlWOClientAgreementEntity;
        }
        public async Task<bool> RemoveWorkOrderVesselClients(string workOrderVesselIdList, CancellationToken ct = default)
        {
            try
            {
                var toBeRemovedWorkOrderVesselClients = await _sql.RetrieveObjectsAsync<WorkOrderVesselClient>(
                    new { WorkOrderVesselIdList = workOrderVesselIdList }, ct);
                if (toBeRemovedWorkOrderVesselClients == null || !toBeRemovedWorkOrderVesselClients.Any())
                    return false;

                foreach (var wovesselclient in toBeRemovedWorkOrderVesselClients)
                {
                    ModelHelper.UpdateModelState(wovesselclient, ObjectState.Deleted, "vjonnadula", DateTime.Now);
                }
                var retWorkOrderVesselClients = await _ef.SaveEntities<WorkOrderVesselClient>(toBeRemovedWorkOrderVesselClients, ct: ct);

                return true;
            }
            catch (Exception ex) { return false; }
        }
        public async Task<bool> RemoveWorkOrderVessel(string workOrderVesselIdList, CancellationToken ct = default)
        {
            try
            {
                var toBeRemovedWorkOrderVessels = await _sql.RetrieveObjectsAsync<WorkOrderVessel>(
                   new { WorkOrderVesselIdList = workOrderVesselIdList }, ct);
                if (toBeRemovedWorkOrderVessels == null || !toBeRemovedWorkOrderVessels.Any())
                    return false;
                foreach (var wovessel in toBeRemovedWorkOrderVessels)
                {
                    ModelHelper.UpdateModelState(wovessel, ObjectState.Deleted, "vjonnadula", DateTime.Now);
                }
                var retWorkOrderVessel = await _ef.SaveEntities<WorkOrderVessel>(toBeRemovedWorkOrderVessels, ct: ct);
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public async Task<bool> RemoveWorkOrderDocuments(string workOrderItemEntityIdList, CancellationToken ct = default)
        {
            var _removeWODocuments = await _sql.RetrieveObjectsAsync<WorkOrderDocument>(
                new { WorkOrderItemEntityIdList = workOrderItemEntityIdList }, ct);
            if (_removeWODocuments == null || !_removeWODocuments.Any())
                return false;

            List<WorkOrderDocument> docsToBeRemoved = new List<WorkOrderDocument>();
            foreach (var docToBeDeleted in _removeWODocuments)
            {
                if (!docToBeDeleted.Stream_Id.HasValue)
                    docToBeDeleted.Stream_Id = Guid.Empty;
                if (!docToBeDeleted.QRCodeStreamId.HasValue)
                    docToBeDeleted.QRCodeStreamId = Guid.Empty;
                ModelHelper.UpdateModelState(docToBeDeleted, ObjectState.Deleted, "vjonnadula", DateTime.Now);
                docsToBeRemoved.Add(docToBeDeleted);
            }
            if (docsToBeRemoved.Count > 0)
            {
                await _ef.SaveEntities<WorkOrderDocument>(docsToBeRemoved);
            }
            return true;
        }
        public async Task<bool> RemoveInvoiceItems(string workOrderItemEntityIdList, CancellationToken ct = default)
        {
            try
            {
                var lWOInvoice = await _sql.RetrieveObjectsAsync<WorkOrderInvoice>(
                                new { WorkOrderItemEntityIdList = workOrderItemEntityIdList }, ct);
                if (lWOInvoice == null || !lWOInvoice.Any()) return false;

                List<int> lWOInvoiceIds = lWOInvoice.Select(x => x.WorkOrderInvoiceId).ToList();
                string woInvoiceIdList = string.Join(",", lWOInvoiceIds);

                var lWOInvoiceItem = await _sql.RetrieveObjectsAsync<WorkOrderInvoiceItem>(
                    new { WorkOrderInvoiceIdList = woInvoiceIdList }, ct);
                lWOInvoice.ForEach((a) => ModelHelper.UpdateModelState(a, ObjectState.Deleted, "vjonnadula", DateTime.Now));
                lWOInvoiceItem.ForEach((a) => ModelHelper.UpdateModelState(a, ObjectState.Deleted, "vjonnadula", DateTime.Now));

                await _ef.SaveEntities<WorkOrderInvoice>(lWOInvoice);
                if (lWOInvoiceItem != null && lWOInvoiceItem.Count > 0)
                    await _ef.SaveEntities<WorkOrderInvoiceItem>(lWOInvoiceItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> RemoveWorkOrderItemEntities(string workOrderItemEntityIdList, CancellationToken ct = default)
        {
            try
            {
                var _removeWOItemEntities = await _sql.RetrieveObjectsAsync<WorkOrderItemEntity>(
                                new { WorkOrderItemEntityIdList = workOrderItemEntityIdList }, ct);
                if (_removeWOItemEntities == null || !_removeWOItemEntities.Any()) return false;
                _removeWOItemEntities.ForEach((a) => ModelHelper.UpdateModelState(a, ObjectState.Deleted, "vjonnadula", DateTime.Now));
                await _ef.SaveEntities<WorkOrderItemEntity>(_removeWOItemEntities);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> RemoveWorkOrderEntity(int workOrderId, string entityIdList, CancellationToken ct = default)
        {
            try
            {
                var toBeRemovedWorkOrderEntities = await _sql.RetrieveObjectsAsync<WorkOrderEntity>(
                                new { WorkOrderId = workOrderId, EntityIdList = entityIdList }, ct);
                if (toBeRemovedWorkOrderEntities == null || !toBeRemovedWorkOrderEntities.Any()) return false;

                toBeRemovedWorkOrderEntities.ForEach((a) => ModelHelper.UpdateModelState(a, ObjectState.Deleted, "vjonnadula", DateTime.Now));
                await _ef.SaveEntities<WorkOrderEntity>(toBeRemovedWorkOrderEntities);
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public async Task<bool> RemoveWOClientAgreementEntityProducts(List<WorkOrderClientAgreementEntity> removeEntities, CancellationToken ct = default)
        {
            try
            {
                List<int> lWorkOrderClientAgreementEntityId = new List<int>();
                lWorkOrderClientAgreementEntityId.AddRange(removeEntities.Select(x => x.WorkOrderClientAgreementEntityId));
                string workOrderClientAgreementEntityIdList = string.Join(",", lWorkOrderClientAgreementEntityId);
                var _removeProducts = await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntityProduct>(
                    new { WorkOrderClientAgreementEntityIdList = workOrderClientAgreementEntityIdList }, ct);
                if (_removeProducts == null) return false;
                _removeProducts.ForEach((a) => ModelHelper.UpdateModelState(a, ObjectState.Deleted, "vjonnadula", DateTime.Now));
                await _ef.SaveEntities<WorkOrderClientAgreementEntityProduct>(_removeProducts);
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public async Task<bool> RemoveWorkOrderClientAgreementEntities(List<WorkOrderClientAgreementEntity> removeEntities, CancellationToken ct = default)
        {
            try
            {
                if (removeEntities != null && removeEntities.Count > 0)
                {
                    removeEntities.ForEach((a) => ModelHelper.UpdateModelState(a, ObjectState.Deleted, "vjonnadula", DateTime.Now));
                    await _ef.SaveEntities<WorkOrderClientAgreementEntity>(removeEntities);
                }
                return true;
            }
            catch (Exception ex) { return false; }
        }
        public async Task<List<WorkOrderClientAgreementEntity>> GetWOClientAgreementEntitiesByWOClientAgreementId(int workOrderClientAgreementId, CancellationToken ct = default)
        {
            return (await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntity>(
                 new { WorkOrderClientAgreementId = workOrderClientAgreementId }, ct)).ToList();
        }
        public async Task<bool> CreateWorkOrderItemEntities(List<WorkOrderClientAgreementEntity> lWOCAEntities, int workOrderId, CancellationToken ct = default)
        {
            if (lWOCAEntities == null || lWOCAEntities.Count == 0)
                return false;
            lWOCAEntities = lWOCAEntities.Where(x => !x.WorkOrderItemEntityId.HasValue).ToList();

            if (lWOCAEntities.Count == 0)
                return false;

            var workOrderEntities = (await _sql.RetrieveObjectsAsync<WorkOrderEntity>(new { WorkOrderId = workOrderId }, ct))
                .Where(x => x.IsChild && x.EntityTypeName == ApplicationConstants.VESSEL && lWOCAEntities.Select(y => y.EntityId).Contains(x.EntityId)).ToList();

            var invoiceItemEntities = (await _sql.RetrieveObjectsAsync<WorkOrderItemEntity>(new { WorkOrderId = workOrderId }, ct)).Where(x => x.IsInvoice).ToList();
            workOrderEntities.RemoveAll(e => invoiceItemEntities.Any(i => i.WorkOrderEntityId == e.WorkOrderEntityId));

            List<WorkOrderItemEntity> newItemEntities = new();
            if (workOrderEntities.Any())
            {
                // Get Invoice WorkOrderItem
                var invoiceItems = await _sql.RetrieveObjectsAsync<WorkOrderItem>(
                    new { WorkOrderId = workOrderId, IsInvoice = true }, ct);

                newItemEntities = await AddWorkOrderItemEntities(invoiceItems, workOrderEntities, ct);
            }
            if (newItemEntities.Any())
            {
                var newItemEntityIds = string.Join(",", newItemEntities.Select(x => x.WorkOrderItemEntityId));
                var createdItemEntities = (await _sql.RetrieveObjectsAsync<WorkOrderItemEntity>(
                    new { WorkOrderItemEntityIdList = newItemEntityIds }, ct))
                    .ToList();

                foreach (var agreement in lWOCAEntities)
                {
                    var matchingEntity = createdItemEntities
                        .FirstOrDefault(x => x.EntityId == agreement.EntityId);

                    if (matchingEntity != null)
                    {
                        agreement.WorkOrderItemEntityId = matchingEntity.WorkOrderItemEntityId;
                        createdItemEntities.Remove(matchingEntity);
                        ModelHelper.UpdateModelState(agreement, ObjectState.Modified, "vjonnadula", DateTime.Now);
                    }
                }

                await _ef.SaveEntities<WorkOrderClientAgreementEntity>(lWOCAEntities);
            }

            return true;
        }
        public async Task<List<WorkOrderItemEntity>> AddWorkOrderItemEntities(IReadOnlyList<WorkOrderItem> lWorkOrderItem, List<WorkOrderEntity> lWorkOrderEntity, CancellationToken ct = default)
        {
            var newEntities = (from workOrderEntity in lWorkOrderEntity
                               from workOrderItem in lWorkOrderItem
                               select new WorkOrderItemEntity
                               { WorkOrderEntityId = workOrderEntity.WorkOrderEntityId, WorkOrderItemId = workOrderItem.WorkOrderItemId }).ToList();

            foreach (var entity in newEntities)
            {
                ModelHelper.UpdateModelState(entity, ObjectState.New, "vjonnadula", DateTime.Now);
            }

            return newEntities.Count == 0 ? newEntities : await _ef.SaveEntities<WorkOrderItemEntity>(newEntities);
        }
        public async Task<bool> UpdateOriginalAnniversaryYear(WorkOrderClientAgreement woClientAgreement, List<WorkOrderClientAgreementEntity> lWorkOrderClientAgreementEntity, CancellationToken ct = default)
        {
            try
            {
                if (lWorkOrderClientAgreementEntity == null || !lWorkOrderClientAgreementEntity.Any())
                    return true;
                lWorkOrderClientAgreementEntity = lWorkOrderClientAgreementEntity.Where(e => e.OriginalAnniversaryYear == null).ToList();

                if (!lWorkOrderClientAgreementEntity.Any())
                    return true;

                var categoryIds = await GetCategoryLookupIdsAsync(woClientAgreement);
                if (!categoryIds.Any())
                    return true;
                var vesselIds = string.Join(",", lWorkOrderClientAgreementEntity.Select(e => e.VesselId));
                var categoryIdList = string.Join(",", categoryIds);

                var vesselInspections = await _sql.RetrieveObjectsAsync<VesselInspectionCertificateDetail>(
                    new { VesselIdList = vesselIds, CategoryIdList = categoryIdList }, ct);

                var originalYearByVessel = vesselInspections
                    .Where(x => x.VesselId.HasValue && x.InspectionType == ApplicationConstants.INSPECTION_TYPE_INTIAL && x.CertificateStatus != ApplicationConstants.CERTIFICATE_STATUS_PENDING).OrderBy(x => x.InspectionDate)
                    .GroupBy(x => x.VesselId.Value)
                .ToDictionary(
                    g => g.Key,
                    g => g.First().InspectionDate);

                var entitiesToUpdate = new List<WorkOrderClientAgreementEntity>();

                foreach (var entity in lWorkOrderClientAgreementEntity)
                {
                    int? year = null;

                    if (entity.VesselId.HasValue && originalYearByVessel.TryGetValue(entity.VesselId.Value, out var inspDate) && inspDate.HasValue)
                    {
                        year = inspDate.Value.Year;
                    }
                    else if (entity.AnniversaryDate.HasValue)
                    {
                        year = entity.AnniversaryDate.Value.Year;
                    }

                    if (year.HasValue)
                    {
                        entity.OriginalAnniversaryYear = year;
                        ModelHelper.UpdateModelState(entity, ObjectState.Modified, "vjonnadula", DateTime.Now);
                        entitiesToUpdate.Add(entity);
                    }
                }

                // Persist updates
                if (entitiesToUpdate.Any())
                    await _ef.SaveEntities<WorkOrderClientAgreementEntity>(entitiesToUpdate);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        private async Task<List<int>> GetCategoryLookupIdsAsync(WorkOrderClientAgreement woClientAgreement)
        {
            if (woClientAgreement == null)
                return new List<int>();

            var lookups = (await _lookupRepo.GetLookupsByTypeName(ApplicationConstants.LOOKUPTYPE_INSPECTION_TYPE_CATEGORY)).ToList();

            var selectedCategories = new List<string>();

            if (woClientAgreement.IsISMOption)
                selectedCategories.Add(ApplicationConstants.INSPECTION_CATEGORY_ISM);

            if (woClientAgreement.IsISPSOption)
                selectedCategories.Add(ApplicationConstants.INSPECTION_CATEGORY_ISPS);

            if (woClientAgreement.IsMLCOption)
                selectedCategories.Add(ApplicationConstants.INSPECTION_CATEGORY_MLC);

            return lookups.Where(l => selectedCategories.Contains(l.Name)).Select(l => l.LookupId).ToList();
        }
        public async Task<WorkOrderDocument> CreateWorkOrderDocument(int systemDocumentId, int workorderItemEntityId, CancellationToken ct = default)
        {
            try
            {
                var document = new WorkOrderDocument
                {
                    SystemDocumentId = systemDocumentId,
                    Stream_Id = Guid.Empty,
                    QRCodeStreamId = Guid.Empty,
                    WorkOrderItemEntityId = workorderItemEntityId,
                    CanRegenerate = true,
                    Reviewed = false,
                    Approved = false,
                    IsDraft = true
                };

                ModelHelper.UpdateModelState(document, ObjectState.New, "vjonnadula", DateTime.Now);

                return await _ef.SaveEntity(document, ct);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<bool> GenerateClientAgreementDocuments(int workOrderId, List<string> docsToGenerate, CancellationToken ct = default)
        {
            List<WorkOrderDocument> lWorkOrderDocument = (await _sql.RetrieveObjectsAsync<WorkOrderDocument>(new { WorkOrderId = workOrderId }, ct)).Where(x => (docsToGenerate.Contains(x.Name))
                                                                                                                              && x.IsOutgoing == true).ToList();
            if (lWorkOrderDocument != null && lWorkOrderDocument.Count > 0)
            {
                lWorkOrderDocument.ForEach(m => { m.CanRegenerate = true; });
                await GenerateDocuments(lWorkOrderDocument, "vjonnadula", ct);
            }
            return true;
        }
        public async Task<bool> GenerateDocuments(List<WorkOrderDocument> documentsToGenerate, string userName, CancellationToken ct = default)
        {
            documentsToGenerate = documentsToGenerate.Where(x => x.IsOutgoing).ToList();
            //string HangfireConnectionString = ConfigurationManager.ConnectionStrings["HangFireStorage"].ToString();
            //JobStorage.Current = new SqlServerStorage(HangfireConnectionString);
            List<WorkOrderDocument> documentsToSave = new List<WorkOrderDocument>();
            List<WorkOrderDocument> filteredDocumentsToSave = new List<WorkOrderDocument>();

            filteredDocumentsToSave = documentsToGenerate.Where(x => !(x.Name == ApplicationConstants.REGISTRATION_PROVISIONALCERTIFICATEOFREGISTRY_EXPEDITE && x.IsCleanDoc)).ToList();

            if (filteredDocumentsToSave != null && filteredDocumentsToSave.Count > 0)
            {
                foreach (var workOrderDocDetail in filteredDocumentsToSave)
                {
                    if (!workOrderDocDetail.Stream_Id.HasValue)
                        workOrderDocDetail.Stream_Id = Guid.Empty;
                    if (!workOrderDocDetail.QRCodeStreamId.HasValue)
                        workOrderDocDetail.QRCodeStreamId = Guid.Empty;
                    ModelHelper.UpdateModelState(workOrderDocDetail, ObjectState.Modified, userName, DateTime.Now);
                    documentsToSave.Add(workOrderDocDetail);
                }
            }
            if (filteredDocumentsToSave.Count > 0)
            {
                await _ef.SaveEntities<WorkOrderDocument>(filteredDocumentsToSave);
            }

            //Hangfire mechanism to generate documents
            //foreach (var workOrderDocDetail in filteredDocumentsToSave)
            //{
            //    if (workOrderDocDetail.CanRegenerate)
            //    {
            //            string ReportParameters =await getReportParameters(workOrderDocDetail.SystemDocumentId,ct);
            //            //document.GenerateAndSaveDocument(workOrderDocDetail.WorkOrderDocumentId, workOrderDocDetail.WorkOrderId, workOrderDocDetail.ReportFileName, ReportParameters);
            //            string jobId = BackgroundJob.Schedule(() => document.GenerateAndSaveDocument(workOrderDocDetail.WorkOrderDocumentId, workOrderDocDetail.WorkOrderId, workOrderDocDetail.ReportFileName, ReportParameters), TimeSpan.FromSeconds(2));
            //    }
            //}//end loop
            return true;
        }
        //documentgeneration part
        //public async Task<string> getReportParameters(int sysDocumentID, CancellationToken ct = default)
        //{
        //    IList<SystemDocumentParameter> templateParameters =await _sql.RetrieveObjectsAsync<SystemDocumentParameter>(
        //        new { SystemDocumentId= _workOrderDocument.SystemDocumentId },ct).ToList();
        //    StringBuilder parameters = new StringBuilder();
        //    foreach (var param in templateParameters)
        //    {
        //        if (parameters.Length > 0) parameters.Append("&");
        //        parameters.Append(param.Name + "=" + _workOrderDocument.GetType().GetProperty(param.Name).GetValue(_workOrderDocument, null).ToString());
        //    }

        //    return parameters.ToString();
        //} 
        public async Task<IReadOnlyList<WorkOrderClientAgreementEntityProduct>> SaveWorkOrderClientAgreementEntityProducts(List<WorkOrderClientAgreementEntityProduct> lWorkOrderClientAgreementEntityProducts, int woClientAgreementId, int entityId, int systemDiscountScheduleId, bool isCustomFees, CancellationToken ct = default)
        {
            if (woClientAgreementId <= 0 || entityId <= 0)
                return Array.Empty<WorkOrderClientAgreementEntityProduct>();

            var woClientAgreementEntity = await _sql.RetrieveObjectAsync<WorkOrderClientAgreementEntity>(
                new { WorkOrderClientAgreementId = woClientAgreementId, EntityId = entityId }, ct);

            if (woClientAgreementEntity == null || woClientAgreementEntity.WorkOrderClientAgreementEntityId <= 0)
                return Array.Empty<WorkOrderClientAgreementEntityProduct>();

            woClientAgreementEntity.SystemDiscountScheduleId = systemDiscountScheduleId;
            woClientAgreementEntity.IsCustomFees = isCustomFees;
            ModelHelper.UpdateModelState(woClientAgreementEntity, ObjectState.Modified, "vjonnadula", DateTime.Now);
            await _ef.SaveEntity(woClientAgreementEntity, ct);

            var existingWOClientAgreementEntityProducts = (await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntityProduct>(new
                { WorkOrderClientAgreementEntityId = woClientAgreementEntity.WorkOrderClientAgreementEntityId,WorkOrderClientAgreementId = woClientAgreementId}, ct)).Where(p => !p.IsAdditionalDiscount).ToList();

            return await SaveProducts(lWorkOrderClientAgreementEntityProducts, existingWOClientAgreementEntityProducts, woClientAgreementEntity.WorkOrderClientAgreementEntityId, woClientAgreementId);
        }
        public async Task<IReadOnlyList<WorkOrderClientAgreementEntityProduct>> SaveProducts(List<WorkOrderClientAgreementEntityProduct> lCurrentProducts, List<WorkOrderClientAgreementEntityProduct> lExistingProducts, int woClientAgreementEntityId, int woClientAgreementId, CancellationToken ct = default)
        {
            if (lExistingProducts != null && lExistingProducts.Count > 0)
            {
                await RemoveProducts(lCurrentProducts, lExistingProducts);

                var updatedProducts = lCurrentProducts.Where(w => lExistingProducts.Any(p => p.SystemProductId == w.SystemProductId)).ToList();

                if (updatedProducts != null && updatedProducts.Count > 0)
                {
                    await UpdateProducts(updatedProducts, woClientAgreementEntityId);
                }

                var newProducts = lCurrentProducts.Where(w => !lExistingProducts.Any(p => p.SystemProductId == w.SystemProductId)).ToList();

                if (newProducts != null && newProducts.Count > 0)
                {
                    await AddProducts(newProducts, woClientAgreementEntityId, woClientAgreementId);
                }
            }
            else
            {
                await AddProducts(lCurrentProducts, woClientAgreementEntityId, woClientAgreementId);
            }
            return await GetWorkOrderClientAgreementEntityProducts(woClientAgreementEntityId);
        }
        public async Task<bool> RemoveProducts(List<WorkOrderClientAgreementEntityProduct> lCurrentProducts, List<WorkOrderClientAgreementEntityProduct> lExisingProducts)
        {
            List<WorkOrderClientAgreementEntityProduct> _removeProducts = lExisingProducts.Where(w => !lCurrentProducts.Any(p => p.SystemProductId == w.SystemProductId)).ToList();
            if (_removeProducts.Count > 0)
            {
                _removeProducts.ForEach((a) => ModelHelper.UpdateModelState(a, ObjectState.Deleted, "vjonnadula", DateTime.UtcNow));
                await _ef.SaveEntities<WorkOrderClientAgreementEntityProduct>(_removeProducts);
            }
            return true;
        }
        public async Task<bool> UpdateProducts(List<WorkOrderClientAgreementEntityProduct> updatedProducts, int woClientAgreementEntityId, CancellationToken ct = default)
        {
            if (updatedProducts == null || updatedProducts.Count == 0)
                return false;

            List<WorkOrderClientAgreementEntityProduct> existingWOClientAgreementEntityProducts = (await _sql.RetrieveObjectsAsync<WorkOrderClientAgreementEntityProduct>(new { WorkOrderClientAgreementEntityId = woClientAgreementEntityId }, ct)).ToList();
            var productsToUpdate = new List<WorkOrderClientAgreementEntityProduct>();
            foreach (var prod in updatedProducts)
            {
                var existingproduct = existingWOClientAgreementEntityProducts.Where(x => x.SystemProductId == prod.SystemProductId).FirstOrDefault();
                existingproduct.DiscountType = prod.DiscountType;
                existingproduct.Amount = prod.Amount;
                existingproduct.IsCustomized = prod.IsCustomized;
                existingproduct.TonnageBilling = prod.TonnageBilling;
                existingproduct.IsOngoingDiscount = prod.IsOngoingDiscount;
                ModelHelper.UpdateModelState(existingproduct, ObjectState.Modified, "vjonnadula", DateTime.UtcNow);
                productsToUpdate.Add(existingproduct);
            }
            if (productsToUpdate.Count > 0)
                await _ef.SaveEntities<WorkOrderClientAgreementEntityProduct>(productsToUpdate, ct: ct);
            return true;
        }
        public async Task<bool> AddProducts(List<WorkOrderClientAgreementEntityProduct> newProducts, int woClientAgreementEntityId, int woClientAgreementId)
        {
            if (newProducts == null || newProducts.Count == 0)
                return false;
            foreach (var product in newProducts)
            {
              product.WorkOrderClientAgreementEntityId = woClientAgreementEntityId;
              product.WorkOrderClientAgreementId = woClientAgreementId;
              ModelHelper.UpdateModelState(product, ObjectState.New, "vjonnadula", DateTime.UtcNow);
            }
            await _ef.SaveEntities<WorkOrderClientAgreementEntityProduct>(newProducts);
            return true;
        }
    }
}
