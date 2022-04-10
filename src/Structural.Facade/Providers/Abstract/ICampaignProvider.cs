namespace Structural.Facade.Providers.Abstract;

public interface ICampaignProvider
{
    ValueTask<Product> GetCampaignAsync(Product product);
}