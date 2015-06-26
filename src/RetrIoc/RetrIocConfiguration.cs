namespace RetrIoc
{
    public class RetrIocConfiguration
    {
        public IContainerBinding ContainerBindings { get; set; }

        public RetrIocConfiguration(IContainerBinding containerBindings)
        {
            ContainerBindings = containerBindings;
        }

        public RetrIocConfiguration()
        {
            
        }
    }
}