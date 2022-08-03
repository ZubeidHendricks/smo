namespace NPOMS.Domain.ResourceParameters
{
	public class EmailQueueResourceParameters : ResourceParametersBase
    {
        public bool OnlyNotSent { get; set; } = false;

        public bool EmailTemplateIsActive { get; set; } = true;
    }
}
