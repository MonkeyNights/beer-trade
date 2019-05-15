## Configura��o de integra��o cont�nua para Android no Appcenter

* Acesse o site do [AppCenter](https://appcenter.ms) e clique em **sign in**:
<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56659112-b2962500-6672-11e9-988a-fe80ca4f947b.png" alt="app_center-1" style="max-width:100%;"/>
	</kbd>
</p>

* Efetue o login com sua conta Microsoft, Git, Facebook, Google ou seu account, criado na plataforma.
> Importante: Ser� necess�rio que a sua conta tenha acesso ao seu reposit�rio do GitHub.

* Ap�s acessar a ferramenta, clique no bot�o **Add New**, no canto superior diretio da tela. Ser�o exibidas duas op��es: **Add New App** e **Add new Organization**.

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56659686-271d9380-6674-11e9-88f1-d30f196db548.png" alt="app_center-2" style="max-width:100%;"/>
	</kbd>
</p>

> Sugest�o: Clique na op��o **Add new Organization** e preencha o campo Name com o valor **Maratona Xamarin**. Com isso, as aplica��es criadas na **Maratona Xamarin** ser�o agrupadas nesta organiza��o.

* Ap�s a cria��o da organiza��o, no centro da tela, clique no bot�o **Add app**. Vamos adicionar o aplicativo Android.

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56659686-271d9380-6674-11e9-88f1-d30f196db548.png" alt="app_center-2" style="max-width:100%;"/>
	</kbd>
</p>

* Em seguida, preencha as informa��es conforme a imagem abaixo e clique em **Add new app**:

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56660304-a5c70080-6675-11e9-9f46-15c479fed091.png" alt="app_center-4" style="max-width:100%;"/>
	</kbd>
</p>

* Aplica��o criada. � hora de adicionar a build. Clique no menu **Build**, em seguinda, em select a service, selecione a op��o **GitHub**.

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56660591-343b8200-6676-11e9-84be-0a06fbc58b50.png" alt="app_center-5" style="max-width:100%;"/>
	</kbd>
</p>

> Importante: fa�a um fork do reposit�rio [beer-trade](https://github.com/MonkeyNights/beer-trade) para que o ele apare�a na lista de reposit�rios associados ao seu usu�rio.

* Selecione o reposit�rio [beer-trade](https://github.com/MonkeyNights/beer-trade) na listagem.

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56660680-6947d480-6676-11e9-8ef3-9830cf64a06b.png" alt="app_center-6" style="max-width:100%;"/>
	</kbd>
</p>

* Selecione a branch master e em seguida, clique no bot�o **Configure build**.

**Abaixo os detalhes dos campos a serem preenchidos/selecionados:**


|                 Campo                    |        Valor selecionado        |
|------------------------------------------|---------------------------------|
|              **Project**                 |     BeerTrade.Android.csproj    |
|           **Configuration**              |            Release              |
|            **SDK Version**               |       Xamarin.Android 9.2       |
|           **Build Scripts**              |              none               |
|          **Build frequency**             | Build this branch on every push |
| **Automatically increment version code** |               On                |
|        **Build number format**           |            Build ID             |
|       **Environment variables**          |              Off                |
|            **SignBuilds**                |               On                |

> Importante: Em Keystore file, ser� necess�rio submeter o arquivo para assinatura do aplicativo Android. Neste caso, se voc� n�o criou o arquivo, acesse o link da [documenta��o](https://docs.microsoft.com/en-us/xamarin/android/deploy-test/signing/manually-signing-the-apk) para cria��o do keystore.

* Em keystore file, efetue o Upload do arquivo criado anteriormente e em seguida informe os dados **Keystore password**, **key alias** e **key password**.

* Clique no bot�o **Save & Build**.

* Tudo pronto!