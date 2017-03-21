using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace WebAutomation.Extensions
{
    [Binding]
    public class CustomTransforms
    {
        [StepArgumentTransformation]
        public DateTime DateTransfrom(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}
