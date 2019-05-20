## Enable and Control Linker

* Description for linker by Microsoft Docs:

> **[Linker on Android](https://docs.microsoft.com/en-us/xamarin/android/deploy-test/linker)**
> Xamarin.Android applications use a linker to reduce the size of the application.
> The linker employes static analysis of your application to determine which assemblies are actually used, which types are actually used, and which members are actually used.
> The linker then behaves like a garbage collector, continually looking for the assemblies, types, and members that are referenced until the entire closure of referenced assemblies, types, and members is found.
> Then everything outside of this closure is discarded.

> **[Linker on IOS](https://docs.microsoft.com/en-us/xamarin/ios/deploy-test/linker)**
> When building your application, Visual Studio for Mac or Visual Studio calls a tool called mtouch that includes a linker for managed code.
> It is used to remove from the class libraries the features that the application is not using.
> The goal is to reduce the size of the application, which will ship with only the necessary bits.


## How to enable it

> _Tip!_ Enable linker **Link all assemblies** option from the beginning of the project to be easier to detect and solve errors.

* Linker options:
    * Don't Link _(None in Visual Studio)_
    * Link SDK Assemblies _(Sdk Assemblies Only)_
    * Link All Assemblies _(Sdk and User Assemblies)_

* Linker on Android:

<p align="center">
	<kbd>
		<img src="https://user-images.githubusercontent.com/19656249/57973894-41524500-7986-11e9-81ec-2f45d8c4e233.png" alt="linker on android" style="max-width:100%;"/>
	</kbd>
</p>


* Linker on IOS:

<p align="center">
	<kbd>
		<img src="https://docs.microsoft.com/pt-br/xamarin/ios/deploy-test/linker-images/linking02w.png" alt="linker on ios" style="max-width:100%;"/>
	</kbd>
</p>


## Control

We can control **linker** with some ways:

* `Preserve` Attribute;
    * If you want to preserve the entire type, you can use the following attribute `[Preserve (AllMembers = true)]`.
    * Sometimes you want to preserve certain members, but only if the containing type was preserved. In those cases, use `[Preserve (Conditional=true)]`.
    * You can also create the `Preserve Attribute` if necessary. To do this, you should just declare a `PreserveAttribute` class and use it in your code, as follows:

>_Important!_ You can use the `Preserve attribute` in any namespace because the linker looks up this attribute by type name.

``` C#
public sealed class PreserveAttribute : System.Attribute {
    public bool AllMembers;
    public bool Conditional;
}
```

* Link skip;
    * It is possible to specify that a set of user-provided `assemblies` should not be linked at all, while allowing other user `assemblies` to be skipped with the _Link SDK Assemblies_ behavior by using the [AndroidLinkSkip MSBuild property](https://docs.microsoft.com/en-us/xamarin/android/deploy-test/building-apps/build-process):

``` XML
<PropertyGroup>
    <AndroidLinkSkip>Assembly1;Assembly2</AndroidLinkSkip>
</PropertyGroup>
```

* LinkerPleaseInclude
    * It is possible to create a class, `LinkerPleaseInclude.cs` to create references to the code snippets so they are not linked.This class will never be executed and when **Linker** is enabled, this class will ensure that types and properties are preserved.

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
    * If the default set of options is not enough, you can drive the linking process with an XML file that describes what you want from the linker.

> Important! Once you have this linker description file, add it to your project and set the **Build Action** to **LinkDescription**

Example:

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

> In the [fifth episode](https://youtu.be/uKo1YN9VJx8) were presented techniques to find and solve situations where the linker removed necessary code of application.

## Related _(pt-Br)_

| [Monkey Nights](https://www.youtube.com/channel/UCFaQBRaoHrAxcGoeY8E5jvQ)  |
|:---------------------------------------------------------------------------------------------:|
|[Habilitando/Resolvendo Linker  ](https://youtu.be/uKo1YN9VJx8) 	                          |
|[Xamarin & Linker, seus Apps até 30% mais leves](https://youtu.be/EzCS7ZeoUQI)      |


|							[Maratona xamarin avançada](https://aka.ms/AA1uvhv)							|
|:---------------------------------------------------------------------------------------------:|
|[Oque é o Linker](https://youtu.be/yRv_9gVoc9M)												|
|[Como diminuir o tamanho do Android Xamarin Forms com o Linker](https://youtu.be/oGDw4_huJeM)	|
|[Como diminuir o tamanho do iOS Xamarin Forms com o Linker](https://youtu.be/0ljqnMSTp80)		|