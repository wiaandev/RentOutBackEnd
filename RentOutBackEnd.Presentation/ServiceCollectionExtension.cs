using HotChocolate.Types.NodaTime;
using HotChocolate.Types.Pagination;
using RentOutBackEnd.Domain;

namespace RentOutBackEnd.Presentation;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddGraph(this IServiceCollection services)
    {
        services
            .AddGraphQLServer()
            .SetPagingOptions(new PagingOptions
            {
                InferConnectionNameFromField = false,
                IncludeTotalCount = true,
                DefaultPageSize = 10,
                MaxPageSize = 10,
                RequirePagingBoundaries = true,
            })
            .AddTypes()
            .AddFiltering()
            .AddProjections()
            // .AddSpatialFiltering()
            // .AddSpatialProjections()
            .AddMutationConventions()
            .RegisterDbContext<AppDbContext>(DbContextKind.Pooled)
            // .AddErrorFilter<ErrorFilter>()
            // .AddDiagnosticEventListener<MyExecutionDiagnosticEventListener>()
            // .AddDiagnosticEventListener<MyDataLoaderEventListener>()
            .AddGlobalObjectIdentification()
            // .AddAuthorization((options) =>
            // {
            //     options.AddPolicy(Constants.PolicyNames.ViewPharmaciesAsAdmin, policy =>
            //     {
            //         policy.RequireAssertion(context =>
            //         {
            //             // Check if the user has the SuperAdmin role
            //             var isSuperAdmin = context.User.IsInRole(Constants.Roles.SuperAdmin);
            //
            //             // Check if the user has the PharmacyAdmin claim
            //             var hasPharmacyAdminClaim = context.User.HasClaim(claim =>
            //                 claim.Type == Constants.ClaimTypes.CustomClaimAdminUserId);
            //
            //             return isSuperAdmin || hasPharmacyAdminClaim;
            //         });
            //     });
            // })
            // .AddType(new TimeSpanType(TimeSpanFormat.DotNet))
            .AddType<OffsetDateTimeType>()
            .AddType<LocalDateType>()
            .AddType<LocalTimeType>()
            .AddType<UploadType>();
        
      

        return services;
    }
}