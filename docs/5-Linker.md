## Habilitanto/Resolvendo Linker

* Descri��o do linker conforme documenta��o da Microsoft:

> **[Linker Android](https://docs.microsoft.com/pt-br/xamarin/android/deploy-test/linker)**
> Aplicativos Xamarin.Android usam um vinculador para reduzir o tamanho do aplicativo.
> O vinculador utiliza uma an�lise est�tica do seu aplicativo para determinar quais assemblies, tipos e membros s�o realmente usados.
> O vinculador, em seguida, se comporta como um coletor de lixo, procurando continuamente assemblies, tipos e membros que s�o referenciados, at� todo o fechamento desses elementos ser encontrado. Tudo fora esse fechamento � descartado.

> **[Linker IOS](https://docs.microsoft.com/pt-br/xamarin/ios/deploy-test/linker?tabs=windows)**
> Ao compilar seu aplicativo, o Visual Studio para Mac ou o Visual Studio chama uma ferramenta chamada mtouch, que inclui um linker para c�digo gerenciado.
> Ele � usado para remover os recursos que o aplicativo n�o est� usando das class libraries.
> A meta � reduzir o tamanho do aplicativo, que ser� fornecido com apenas as partes necess�rias.


## Habilitando Linker

> _Dica!_ Utilize o Linker, desde o in�cio do projeto, no modo mais agressivo. Dessa forma fica mais f�cil e natural resolver situa��es adversas.

* Op��es do linker:
    * N�o Vincular _(Nenhum no Visual Studio)_
    * Vincular os Assemblies do SDK _(Somente os Assemblies do SDK)_
    * Vincular Todos os Assemblies _(Assemblies de SDK e de Usu�rio)_

* Linker no Android:

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/19656249/57973894-41524500-7986-11e9-81ec-2f45d8c4e233.png" alt="linker on android" style="max-width:100%;"/>
	</kbd>
</p>


* Linker no IOS:

<p align="center">
	<kbd>
		<img src="https://docs.microsoft.com/pt-br/xamarin/ios/deploy-test/linker-images/linking02w.png" alt="linker on ios" style="max-width:100%;"/>
	</kbd>
</p>


## Controlando o Linker

� poss�vel controlar o **linker** atrav�s das seguintes formas:

* Atributo `Preserve`;
    * Voc� pode aplicar esse atributo a todos os membros de um tipo ou ao tipo propriamente dito. Se voc� quiser preservar o tipo inteiro, poder� usar a sintaxe `[Preserve (AllMembers = true)]` no tipo.
    * �s vezes voc� deseja preservar a certos membros, mas somente se o tipo recipiente foi preservado. Nesses casos, use `[Preserve (Conditional=true)]`.
    * Tamb�m � poss�vel criar o `PreserveAttribute`, caso necess�rio. Para fazer isso, voc� apenas deve declarar uma classe `PreserveAttribute` e us�-la em seu c�digo, deste modo:

>_Importante!_ N�o importa em qual `namespace` isso � definido, o **linker** procura esse atributo pelo nome do tipo.

``` C#
public sealed class PreserveAttribute : System.Attribute {
    public bool AllMembers;
    public bool Conditional;
}
```

* Link skip;
    * � poss�vel especificar que um conjunto de `assemblies` fornecidos pelo usu�rio n�o sejam vinculados, permitindo simultaneamente que outros `assemblies` de usu�rio sejam ignorados com o comportamento _Vincular Assemblies de SDK_ usando a [Propriedade AndroidLinkSkip do MSBuild](https://docs.microsoft.com/pt-br/xamarin/android/deploy-test/building-apps/build-process):

``` XML
<PropertyGroup>
    <AndroidLinkSkip>Assembly1;Assembly2</AndroidLinkSkip>
</PropertyGroup>
```

* LinkerPleaseInclude
    * � poss�vel criar uma classe, `LinkerPleaseInclude.cs` para criar refer�ncias para os trechos de c�digos para que n�o sejam vinculados. Esta classe nunca ser� executada, mas quando o **Linker** estiver ativado, vai garantir que os tipos e propriedades ser�o preservados.

```C#
public sealed class LinkerPleaseInclude
{
        public void Include(Button button)
        {
            button.Click += (s,e) => button.Text = button.Text + "";
        }
}
```

* Linker.Xml
    * Se o conjunto padr�o de op��es n�o for o suficiente, fa�a o processo de vincula��o com um arquivo XML que descreve o que voc� deseja do vinculador.

> Importante! Quando voc� tiver esse arquivo de descri��o de vinculador, adicione-o ao seu projeto e defina a **A��o de Build** para **LinkDescription**

Exemplo:

``` Xml
<linker>
        <assembly fullname="mscorlib">
                <type fullname="System.Environment">
                        <field name="mono_corlib_version" />
                        <method name="get_StackTrace" />
                </type>
        </assembly>
        <assembly fullname="My.Own.Assembly">
                <type fullname="Foo" preserve="fields">
                        <method name=".ctor" />
                </type>
                <type fullname="Bar">
                        <method signature="System.Void .ctor(System.String)" />
                        <field signature="System.String _blah" />
                </type>
                <namespace fullname="My.Own.Namespace" />
                <type fullname="My.Other*" />
        </assembly>
</linker>
```

> No [quinto epis�dio](https://youtu.be/uKo1YN9VJx8) foram apresentadas t�cnicas para encontrar e resolver situa��es em que o linker removeu c�digo necess�rio para execu��o plena do aplicativo.


## Material adicional

| [Monkey Nights](https://www.youtube.com/channel/UCFaQBRaoHrAxcGoeY8E5jvQ)  |
|:---------------------------------------------------------------------------------------------:|
|[Habilitando/Resolvendo Linker  ](https://youtu.be/uKo1YN9VJx8) 	                          |
|[Xamarin & Linker, seus Apps at� 30% mais leves](https://youtu.be/EzCS7ZeoUQI)      |


|							[Maratona xamarin avan�ada](https://aka.ms/AA1uvhv)							|
|:---------------------------------------------------------------------------------------------:|
|[Oque � o Linker](https://youtu.be/yRv_9gVoc9M)												|
|[Como diminuir o tamanho do Android Xamarin Forms com o Linker](https://youtu.be/oGDw4_huJeM)	|
|[Como diminuir o tamanho do iOS Xamarin Forms com o Linker](https://youtu.be/0ljqnMSTp80)		|