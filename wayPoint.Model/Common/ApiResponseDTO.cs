using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WayPoint.Model.Common
{
	public class ApiResponseDTO<T>
	{
		public bool Success { get; set; }
		public string? ErrorMessage { get; set; }
		public T? Data { get; set; }

		public static ApiResponseDTO<T> Ok(T data)
		{
			return new ApiResponseDTO<T>
			{
				Success = true,
				Data = data,
				ErrorMessage = null
			};
		}

		public static ApiResponseDTO<T> Fail(string error)
		{
			return new ApiResponseDTO<T>
			{
				Success = false,
				Data = default,
				ErrorMessage = error
			};
		}

	}

}
