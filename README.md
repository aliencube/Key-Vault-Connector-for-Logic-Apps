# Key Vault Connector for Logic Apps #

This provides a custom Key Vault API Connector for Logic Apps.


## Background ##

Currently [Microsoft Logic App](https://azure.microsoft.com/en-us/services/logic-apps/) doesn't provide a Logic App connector for [Azure Key Vault](https://azure.microsoft.com/en-us/services/key-vault/). Although there is a [workaround to get access to Key Vault directly from the Logic App](https://devkimchi.com/2018/10/24/accessing-key-vault-from-logic-apps-with-managed-identity/), it would be easier to use an API connection like [any other connectors](https://docs.microsoft.com/en-us/azure/connectors/apis-list).

Therefore, this repository offers a custom API using [Azure Functions](https://azure.microsoft.com/en-us/services/functions/) to access to Key Vault.


## More Readings ##

* 한국어: TBD
* English: TBD


## Getting Started ##

This consists of several components using Azure products/services:

* Azure Storage Account
* Azure Application Insights
* Azure Consumption Plan
* Azure Functions
* Azure Logic Apps Custom Connector
* Azure API Connection - Custom Connector
* Azure Logic App
* Azure Key Vault

> **NOTE**: The Logic App instance is for testing purpose.


### Deployment through Azure Portal ###

Click the button below to deploy the ARM template through Azure Portal:

<a href="https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Faliencube%2FKey-Vault-Connector-for-Logic-Apps%2Fmaster%2Fazuredeploy.json" target="_blank">
  <img src="https://azuredeploy.net/deploybutton.png" />
</a>


### Deployment through Azure PowerShell ###

Alternatively, deploy it through Azure PowerShell.

1. Login to Azure Resource Manager through PowerShell.

    ```powershell
    Login-AzureRmAccount
    ```
1. Create a resource group.

    ```powershell
    New-AzureRmResourceGroup `
        -Name "[RESOURCE_GROUP_NAME]" `
        -Location "[LOCATION]"
    ```

1. Update `azuredeploy.parameters.json`.
1. Deploy the ARM template.

    ```powershell
    New-AzureRmResourceGroupDeployment `
        -Name KeyVaultConnector `
        -ResourceGroupName "[RESOURCE_GROUP_NAME]" `
        -TemplateFile "azuredeploy.json" `
        -TemplateParameterFile "azuredeploy.parameters.json" `
        -Verbose
    ```

### Deployment through Azure CLI ###

You can also use Azure CLI for ARM template deployment.

1. Login to Azure Resource Manager through Azure CLI.

    ```bash
    az login
    ```
1. Create a resource group.

    ```bash
    az group create \
        --name [RESOURCE_GROUP_NAME] \
        --location [LOCATION]
    ```

1. Update `azuredeploy.parameters.json`.
1. Deploy the ARM template.

    ```bash
    az group deployment create \
        --name KeyVaultConnector \
        --resource-group [RESOURCE_GROUP_NAME] \
        --template-file azuredeploy.json \
        --parameters @azuredeploy.parameters.json \
        --verbose
    ```

> **NOTE**: This is using nested ARM template deployment. If you are not sure how it works, deploy each ARM template individually in the following order:
>
> 1. `src/KeyVaultConnector.Resources/StorageAccount.json`
> 1. `src/KeyVaultConnector.Resources/ApplicationInsights.json`
> 1. `src/KeyVaultConnector.Resources/ConsumptionPlan.json`
> 1. `src/KeyVaultConnector.Resources/FunctionApp.json`
> 1. `src/KeyVaultConnector.Resources/CustomApi-KeyVault.json`
> 1. `src/KeyVaultConnector.Resources/ApiConnection-KeyVault.json`
> 1. `src/KeyVaultConnector.Resources/LogicApp.json`
> 1. `src/KeyVaultConnector.Resources/KeyVault.json`


### Deploy Azure Functions Application ###

Once all Azure resources are deployed, deploy the Azure Functions application through Visual Studio, Visual Studio Code, Azure CLI or CI/CD pipeline.


### Create Secrets onto Key Vault ###

If there is no secrets on Azure Key Vault, create some. It may require to add your credentials to Key Vault access policies.


### Authorise API Connection with Azure Function Host Key ###

Get the host key for Azure Functions from the settings and authorise the API connection.


### Test Custom Connector ###

Use the Logic App instance deployed, simply run it with the payload below:

```json
{
  "secretName": "[SECRET_NAME]"
}
```


## Contribution ##

Your contributions are always welcome! All your work should be done in your forked repository. Once you finish your work with corresponding tests, please send us a pull request onto our `dev` branch for review.


## License ##

**Key Vault Connector for Logic Apps** is released under [MIT License](http://opensource.org/licenses/MIT)

> The MIT License (MIT)
>
> Copyright (c) 2018 [aliencube.org](https://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
