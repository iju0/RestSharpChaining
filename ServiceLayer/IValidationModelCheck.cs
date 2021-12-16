namespace ServiceLayer
{
    public interface IValidationModelCheck
    {
        void ValidateModel<TDomainModel>(TDomainModel domainModel);
    }
}