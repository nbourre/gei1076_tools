using nick_wpf_tools.ViewModels;
using System;
using Xunit;

namespace tools_tests
{
    
    public class ToolsTests
    {
        [Fact]
        public void ClosePort_MustReturnFalseIfNotOpen()
        {            
            SerialPortViewModel sp = new SerialPortViewModel();

            var actual = sp.Close();

            Assert.False(actual);
        }
    }
}
