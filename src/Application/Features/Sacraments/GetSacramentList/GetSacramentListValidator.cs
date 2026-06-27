namespace Application.Features.Sacraments.GetSacramentList;

public static class GetSacramentListValidator
{
    public static List<string> Validate(GetSacramentListRequest request)
    {
        var errors = new List<string>();

        if (request.PageNumber <= 0)
            errors.Add("PageNumber must be greater than 0.");

        if (request.PageSize <= 0)
            errors.Add("PageSize must be greater than 0.");

        return errors;
    }
}