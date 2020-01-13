using System.Collections.Generic;
using HotChocolate.Language;
using HotChocolate.Properties;
using HotChocolate.Resolvers;

namespace HotChocolate.Types.Introspection
{
    [Introspection]
    internal sealed class __Directive
        : ObjectType
    {
        protected override void Configure(
            IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("__Directive");

            descriptor.Description(TypeResources.Directive_Description);

            descriptor.Field("name")
                .NonNullType(Scalars.String)
                .Resolver(c => c.Parent<DirectiveType>().Name);

            descriptor.Field("description")
                .Type(Scalars.String)
                .Resolver(c => c.Parent<DirectiveType>().Description);

            descriptor.Field("isRepeatable")
                .NonNullType(Scalars.String)
                .Resolver(c => c.Parent<DirectiveType>().IsRepeatable);

            descriptor.Field("locations")
                .Type<NonNullType<ListType<NonNullType<__DirectiveLocation>>>>()
                .Resolver(c => c.Parent<DirectiveType>().Locations);

            descriptor.Field("args")
                .Type<NonNullType<ListType<NonNullType<__InputValue>>>>()
                .Resolver(c => c.Parent<DirectiveType>().Arguments);

            descriptor.Field("onOperation")
                .NonNullType(Scalars.Boolean)
                .Resolver(c => GetOnOperation(c))
                .Deprecated(TypeResources.Directive_UseLocation);

            descriptor.Field("onFragment")
                .NonNullType(Scalars.Boolean)
                .Resolver(c => GetOnFragment(c))
                .Deprecated(TypeResources.Directive_UseLocation);

            descriptor.Field("onField")
                .NonNullType(Scalars.Boolean)
                .Resolver(c => GetOnField(c))
                .Deprecated(TypeResources.Directive_UseLocation);
        }

        private static bool GetOnOperation(IResolverContext context)
        {
            ICollection<DirectiveLocation> locations =
                context.Parent<DirectiveType>().Locations;

            return locations.Contains(DirectiveLocation.Query)
                || locations.Contains(DirectiveLocation.Mutation)
                || locations.Contains(DirectiveLocation.Subscription);
        }

        private static bool GetOnFragment(IResolverContext context)
        {
            ICollection<DirectiveLocation> locations =
                context.Parent<DirectiveType>().Locations;

            return locations.Contains(DirectiveLocation.InlineFragment)
                || locations.Contains(DirectiveLocation.FragmentSpread)
                || locations.Contains(DirectiveLocation.FragmentDefinition);
        }

        private static bool GetOnField(IResolverContext context)
        {
            ICollection<DirectiveLocation> locations =
                context.Parent<DirectiveType>().Locations;

            return locations.Contains(DirectiveLocation.Field);
        }
    }
}
