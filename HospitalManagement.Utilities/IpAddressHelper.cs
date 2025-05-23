using Microsoft.AspNetCore.Http;

namespace HospitalManagement.Utilities
{
    public static class IpAddressHelper
    {
        public static string GetClientIpAddress(HttpContext context)
        {
            // First, try to get the IP address from the headers
            string ipAddress = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            // If X-Forwarded-For header is not present, try to get the IP address from the connection
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = context.Connection.RemoteIpAddress?.ToString();
                //if (ipAddress != null)
                //{
                //    if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
                //    {
                //        ipAddress = Dns.GetHostEntry(ipAddress).AddressList.First(x => x.AddressFamily == AddressFamily.InterNetwork);
                //    }
                   
                //}
            }

            // If both X-Forwarded-For and connection's RemoteIpAddress are not available, use localhost
            if (string.IsNullOrEmpty(ipAddress))
            {
                ipAddress = "192.168.1.88";
            }

            return ipAddress;
        }
    }
}
