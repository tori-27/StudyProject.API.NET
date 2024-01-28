using k8s;



namespace StudyProject.Services
{
    public class KubernetesClientService
    {
        private IKubernetes _client;

        public void Initialize(byte[] kubeConfigContent)
        {
            var config = KubernetesClientConfiguration.BuildConfigFromConfigFile(new MemoryStream(kubeConfigContent));
            _client = new Kubernetes(config);
        }

        public IKubernetes GetClient()
        {
            return _client;
        }
    }
}

