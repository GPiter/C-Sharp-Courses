namespace MyPhotoshop
{
    public abstract class ParametrizedFilter : IFilter
    {
        IParameters parameters;

        public ParametrizedFilter(IParameters parameters)
        {
            this.parameters = parameters;
        }

        public ParameterInfo[] GetParameters()
        {
            return parameters.GetDesсription();
        }

        public abstract Photo Process(Photo original, IParameters parameters);

        public Photo Process(Photo original, double[] parameters)
        {
            this.parameters.Parse(parameters);
            return Process(original, this.parameters);
        }
    }
}
