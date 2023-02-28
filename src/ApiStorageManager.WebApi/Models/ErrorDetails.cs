﻿using System.Text.Json;

namespace ApiStorageManager.WebApi.Models
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public string Details { get; set; }
        public string TraceId { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
