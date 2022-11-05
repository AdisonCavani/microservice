# microservice

Microservice

### K8S

ingress nginx:

```
kubectl apply -f https://raw.githubusercontent.com/kubernetes/ingress-nginx/controller-v1.3.0/deploy/static/provider/cloud/deploy.yaml
```

postgresql secret(password):

```
kubectl create secret generic postgresql --from-literal=POSTGRES_PASSWORD="password"
```
