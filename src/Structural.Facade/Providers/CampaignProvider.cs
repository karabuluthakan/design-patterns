namespace Structural.Facade.Providers;

public class CampaignProvider : ICampaignProvider
{
    public async ValueTask<Product> GetCampaignAsync(Product product)
    {
        product.Price *= (decimal)0.9;
        return product;
    }
}