## Habilitanto/Resolvendo Linker

* Descrição do linker conforme documentação da Microsoft:

> **[Linker Android](https://docs.microsoft.com/pt-br/xamarin/android/deploy-test/linker)**
> Aplicativos Xamarin.Android usam um vinculador para reduzir o tamanho do aplicativo.
> O vinculador utiliza uma análise estática do seu aplicativo para determinar quais assemblies, tipos e membros são realmente usados.
> O vinculador, em seguida, se comporta como um coletor de lixo, procurando continuamente assemblies, tipos e membros que são referenciados, até todo o fechamento desses elementos ser encontrado. Tudo fora esse fechamento é descartado.

> **[Linker IOS](https://docs.microsoft.com/pt-br/xamarin/ios/deploy-test/linker?tabs=windows)**
> Ao compilar seu aplicativo, o Visual Studio para Mac ou o Visual Studio chama uma ferramenta chamada mtouch, que inclui um linker para código gerenciado.
> Ele é usado para remover os recursos que o aplicativo não está usando das class libraries.
> A meta é reduzir o tamanho do aplicativo, que será fornecido com apenas as partes necessárias.


## Habilitando Linker

> _Dica!_ Utilize o Linker, desde o início do projeto, no modo mais agressivo. Dessa forma fica mais fácil e natural resolver situações adversas.

* Opções do linker:
    * Não Vincular _(Nenhum no Visual Studio)_
    * Vincular os Assemblies do SDK _(Somente os Assemblies do SDK)_
    * Vincular Todos os Assemblies _(Assemblies de SDK e de Usuário)_

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

É possível controlar o **linker** através das seguintes formas:

* Atributo `Preserve`;
    * Você pode aplicar esse atributo a todos os membros de um tipo ou ao tipo propriamente dito. Se você quiser preservar o tipo inteiro, poderá usar a sintaxe `[Preserve (AllMembers = true)]` no tipo.
    * Às vezes você deseja preservar a certos membros, mas somente se o tipo recipiente foi preservado. Nesses casos, use `[Preserve (Conditional=true)]`.
    * Também é possível criar o `PreserveAttribute`, caso necessário. Para fazer isso, você apenas deve declarar uma classe `PreserveAttribute` e usá-la em seu código, deste modo:

>_Importante!_ Não importa em qual `namespace` isso é definido, o **linker** procura esse atributo pelo nome do tipo.

``` C#
public sealed class PreserveAttribute : System.Attribute {
    public bool AllMembers;
    public bool Conditional;
}
```

* Link skip;
    * É possível especificar que um conjunto de `assemblies` fornecidos pelo usuário não sejam vinculados, permitindo simultaneamente que outros `assemblies` de usuário sejam ignorados com o comportamento _Vincular Assemblies de SDK_ usando a [Propriedade AndroidLinkSkip do MSBuild](https://docs.microsoft.com/pt-br/xamarin/android/deploy-test/building-apps/build-process):

``` XML
<PropertyGroup>
    <AndroidLinkSkip>Assembly1;Assembly2</AndroidLinkSkip>
</PropertyGroup>
```

* LinkerPleaseInclude
    * É possível criar uma classe, `LinkerPleaseInclude.cs` para criar referências para os trechos de códigos para que não sejam vinculados. Esta classe nunca será executada, mas quando o **Linker** estiver ativado, vai garantir que os tipos e propriedades serão preservados.

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
    * Se o conjunto padrão de opções não for o suficiente, faça o processo de vinculação com um arquivo XML que descreve o que você deseja do vinculador.

> Importante! Quando você tiver esse arquivo de descrição de vinculador, adicione-o ao seu projeto e defina a **Ação de Build** para **LinkDescription**

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

> No [quinto episódio](https://youtu.be/uKo1YN9VJx8) foram apresentadas técnicas para encontrar e resolver situações em que o linker removeu código necessário para execução plena do aplicativo.


## Material adicional

| [Monkey Nights](https://www.youtube.com/channel/UCFaQBRaoHrAxcGoeY8E5jvQ)  |
|:---------------------------------------------------------------------------------------------:|
|[Habilitando/Resolvendo Linker  ](https://youtu.be/uKo1YN9VJx8) 	                          |
|[Xamarin & Linker, seus Apps até 30% mais leves](https://youtu.be/EzCS7ZeoUQI)      |


|							[Maratona xamarin avançada](https://aka.ms/AA1uvhv)							|
|:---------------------------------------------------------------------------------------------:|
|[Oque é o Linker](https://youtu.be/yRv_9gVoc9M)												|
|[Como diminuir o tamanho do Android Xamarin Forms com o Linker](https://youtu.be/oGDw4_huJeM)	|
|[Como diminuir o tamanho do iOS Xamarin Forms com o Linker](https://youtu.be/0ljqnMSTp80)		|