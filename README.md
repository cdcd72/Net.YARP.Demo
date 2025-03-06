# Net.YARP.Demo

> 這個專案專注於利用 YARP 來實作 API Gateway。  
> The project focuses on implementing an API Gateway using YARP.

練習 YARP 實作 API Gateway。  
To practice how YARP implement API Gateway.

## 待實作

- [ ] 認證授權
- [ ] 健康檢查
- [ ] 要求逾時
- [ ] 分散追蹤
- [ ] CORS

## 運行專案

> 開啟終端機至專案根目錄並執行以下指令

1. Open the terminal to the project's root directory and execute the following command.

   ```shell
   (docker or podman) compose -p yarp-demo up -d
   ```

> 透過 `GatewayApi` 呼叫 `ProductsApi`

2. Call `ProductsApi` through `GatewayApi`.

   ```shell
   curl -X GET --location "http://localhost:5000/products-api/products/1" -H "Accept: application/json"
   ```

   > 回應如下：

   The response is as follows:

   ```json
   {
     "id": "1",
     "name": "Apple"
   }
   ```

> 透過 `GatewayApi` 呼叫 `SalesApi`

3. Call `SalesApi` through `GatewayApi`.

   ```shell
   curl -X GET --location "http://localhost:5000/sales-api/sales/1" -H "Accept: application/json"
   ```

   > 回應如下：

   The response is as follows:

   ```json
   {
     "id": "1",
     "name": "Ame"
   }
   ```

> 透過 `GatewayApi` 呼叫 `UsersApi`

4. Call `UsersApi` through `GatewayApi`.

   ```shell
   curl -X GET --location "http://localhost:5000/sales-api/sales/1" -H "Accept: application/json"
   ```

   > 回應如下：

   The response is as follows:

   ```json
   {
     "id": "1",
     "name": "Ben"
   }
   ```

> 嘗試自己玩看看

5. Try it yourself.
