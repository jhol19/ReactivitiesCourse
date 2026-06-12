using System;

namespace Application.profiles.DTOs
{
    public class PhotoUploadResult
    {
        public required string PublicId { get; set; }
        public required string Url { get; set; }
    }
}