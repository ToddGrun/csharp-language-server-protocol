﻿using System;
using FluentAssertions;
using Lsp.Models;
using Newtonsoft.Json;
using Xunit;

namespace Lsp.Tests.Models
{
    public class DidOpenTextDocumentParamsTests
    {
        [Theory, JsonFixture]
        public void SimpleTest(string expected)
        {
            var model = new DidOpenTextDocumentParams() {
                TextDocument = new TextDocumentItem() {
                    Uri = new Uri("file:///abc/def.cs"),
                    LanguageId = "csharp",
                    Text = "content",
                    Version = 1
                }
            };
            var result = Fixture.SerializeObject(model);
            
            result.Should().Be(expected);

            var deresult = JsonConvert.DeserializeObject<DidOpenTextDocumentParams>(expected);
            deresult.ShouldBeEquivalentTo(model);
        }
    }
}
