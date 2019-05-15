## Continuous integration settings for Android on Appcenter

* Access [AppCenter](https://appcenter.ms) website and click the **Sign in** button:
<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56659112-b2962500-6672-11e9-988a-fe80ca4f947b.png" alt="app_center-1" style="max-width:100%;"/>
	</kbd>
</p>

* Log in with your Microsoft, Git, Facebook, Google or custom account.
> Important: It will be necessary, for your account, to have access to your GitHub repository.

* After accessing the tool, click the **Add New** button in the upper right corner of the screen. There are two options: **Add New App** and **Add new Organization**.

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56659686-271d9380-6674-11e9-88f1-d30f196db548.png" alt="app_center-2" style="max-width:100%;"/>
	</kbd>
</p>

> Suggestion: Select the option **Add new Organization** and fill in the Name field with value **Maratona Xamarin**. Before that, the created applications on **Maratona Xamarin** will be group in this organization.

* After the organization has been created, in the center of the screen, click the **Add app** button. Let's add the Android app.

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56659686-271d9380-6674-11e9-88f1-d30f196db548.png" alt="app_center-2" style="max-width:100%;"/>
	</kbd>
</p>

* Then fill in the information as shown below and click **Add new app** button:

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56660304-a5c70080-6675-11e9-9f46-15c479fed091.png" alt="app_center-4" style="max-width:100%;"/>
	</kbd>
</p>

* Application created! Now, to add the build click on the menu **Build**, then select the option **GitHub** on select a service field .

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56660591-343b8200-6676-11e9-84be-0a06fbc58b50.png" alt="app_center-5" style="max-width:100%;"/>
	</kbd>
</p>


> Important: Create a fork from the [beer-trade](https://github.com/MonkeyNights/beer-trade) repository, so that it will be appears in the list of repositories associated with your user.

* Select the [beer-trade](https://github.com/MonkeyNights/beer-trade) repository.

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/25234977/56660680-6947d480-6676-11e9-8ef3-9830cf64a06b.png" alt="app_center-6" style="max-width:100%;"/>
	</kbd>
</p>

* Select the master branch and click **Configure build** button.

**Below the details of the fields, on build configuration, that has been setted:**


|                 Field                    |         Selected Value          |
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

> Important: In Keystore file, you will need to submit the file for Android application subscription. In this case, if you didn't create the file, access the [documentation](https://docs.microsoft.com/en-us/xamarin/android/deploy-test/signing/manually-signing-the-apk) link for creating the keystore.

* Upload the Keystore file created previously and then enter the data **Keystore password**, **key alias** and **key password**.

* Click **Save & Build** button.

* Done!