﻿using System.Collections.Generic;
using HotChocolate.Language.Utilities;

namespace HotChocolate.Language
{
    public sealed class InterfaceTypeExtensionNode
        : InterfaceTypeDefinitionNodeBase
        , ITypeExtensionNode
    {
        public InterfaceTypeExtensionNode(
            Location? location,
            NameNode name,
            IReadOnlyList<DirectiveNode> directives,
            IReadOnlyList<FieldDefinitionNode> fields)
            : base(location, name, directives, fields)
        {
        }

        public override NodeKind Kind { get; } = NodeKind.InterfaceTypeExtension;

        public override IEnumerable<ISyntaxNode> GetNodes()
        {
            yield return Name;

            foreach (DirectiveNode directive in Directives)
            {
                yield return directive;
            }

            foreach (FieldDefinitionNode field in Fields)
            {
                yield return field;
            }
        }

        /// <summary>
        /// Returns the GraphQL syntax representation of this <see cref="ISyntaxNode"/>.
        /// </summary>
        /// <returns>
        /// Returns the GraphQL syntax representation of this <see cref="ISyntaxNode"/>.
        /// </returns>
        public override string ToString() => SyntaxPrinter.Print(this, true);

        /// <summary>
        /// Returns the GraphQL syntax representation of this <see cref="ISyntaxNode"/>.
        /// </summary>
        /// <param name="indented">
        /// A value that indicates whether the GraphQL output should be formatted,
        /// which includes indenting nested GraphQL tokens, adding
        /// new lines, and adding white space between property names and values.
        /// </param>
        /// <returns>
        /// Returns the GraphQL syntax representation of this <see cref="ISyntaxNode"/>.
        /// </returns>
        public override string ToString(bool indented) => SyntaxPrinter.Print(this, indented);

        public InterfaceTypeExtensionNode WithLocation(Location? location)
        {
            return new InterfaceTypeExtensionNode(
                location, Name, Directives, Fields);
        }

        public InterfaceTypeExtensionNode WithName(NameNode name)
        {
            return new InterfaceTypeExtensionNode(
                Location, name, Directives, Fields);
        }

        public InterfaceTypeExtensionNode WithDirectives(
            IReadOnlyList<DirectiveNode> directives)
        {
            return new InterfaceTypeExtensionNode(
                Location, Name, directives, Fields);
        }

        public InterfaceTypeExtensionNode WithFields(
            IReadOnlyList<FieldDefinitionNode> fields)
        {
            return new InterfaceTypeExtensionNode(
                Location, Name, Directives, fields);
        }
    }
}
