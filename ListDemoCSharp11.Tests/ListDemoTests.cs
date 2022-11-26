namespace ListDemoCSharp11.Tests
{
    public class ListDemoTests
    {
        [Fact]
        public void List_parse_parseresult_success()
        {
            var partsResult = new Parts("a", "b", "c");

            var parsedResult = Parts.Parse(partsResult.ToString());

            parsedResult.Part1.Should().Be("a");
            parsedResult.Part2.Should().Be("b");
            parsedResult.Part3.Should().Be("c");
        }

        [Fact]
        public void List_parse_parseresult_tostring_success()
        {
            var partsResult = new Parts("a", "b", "c");

            var result = partsResult.ToString();

            result.Should().Be("a|b|c");
        }

        [Fact]
        public void List_parse_parseresult_throws_invalidoperationexception()
        {
            var partsResult = new Parts("a", "b", "c");

            var parsedResult = Parts.Parse(partsResult.ToString());

            Action act = () => Parts.Parse(parsedResult.ToString() + "|d");
            
            act.Should().Throw<InvalidOperationException>();
        }
    }
}