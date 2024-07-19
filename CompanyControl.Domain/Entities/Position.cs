using System.ComponentModel;

namespace CompanyControl.Domain.Entities
{
    public enum Position
    {
        [Description("Менеджер")]
        Manager,

        [Description("Инженер")]
        Engineer,

        [Description("Тестировщик свечей")]
        Tester
    }
}
