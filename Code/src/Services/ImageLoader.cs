namespace BettingSystem.Services
{
    public class ImageLoader
    {
        private static readonly HttpClient client = new HttpClient();
        public async Task<Image> GetImageAsync(string url)
        {
            try
            {
                //image from a folder
                if (File.Exists(url))
                {
                    return Image.FromFile(url);
                }
                //image from web
                using (Stream stream = await client.GetStreamAsync(url))
                {
                    return Image.FromStream(stream);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading image: {ex.Message}");
                return null; 
            }
        }
    }
}