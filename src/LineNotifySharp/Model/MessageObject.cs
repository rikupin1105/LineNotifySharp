using System;

namespace LineNotifySharp.Model
{
    public class MessageObject
    {
        public MessageObject(string message, string? imageThumbnail = null, string? imageFullsize = null, string? imageFile = null, int? stickerPackageId = null, int? stickerId = null, bool? notificationDisabled = false)
        {
            Message = message ?? throw new ArgumentNullException(nameof(message));
            ImageThumbnail = imageThumbnail;
            ImageFullsize = imageFullsize;
            ImageFile = imageFile;
            StickerPackageId = stickerPackageId;
            StickerId = stickerId;
            NotificationDisabled = notificationDisabled;
        }

        public string Message { get; set; }
        public string? ImageThumbnail { get; set; }
        public string? ImageFullsize { get; set; }
        public string? ImageFile { get; set; }
        public int? StickerPackageId { get; set; }
        public int? StickerId { get; set; }
        public bool? NotificationDisabled { get; set; }

    }
}
