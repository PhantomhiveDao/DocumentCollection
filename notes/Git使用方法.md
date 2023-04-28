> 2021年8月开始改成只能由token登录了。ssh配置没用。
> 参考这篇博客吧：https://blog.csdn.net/yjw123456/article/details/119696726
> 以下是chatgpt的回答：
>
> 这个错误提示是因为在2021年8月13日，GitHub停止支持使用密码进行身份验证，这是为了提高安全性。相反，您需要使用访问令牌（access token）或SSH密钥进行身份验证。
>
> 要解决此问题，您可以按照以下步骤：
>
> \1. 在GitHub上创建一个访问令牌。您可以在GitHub的设置页面中创建令牌。在页面的左侧菜单中选择“Developer Settings”，然后选择“Personal access tokens”。在此页面上，选择“Generate new token”按钮，然后按照页面中的说明进行操作。请确保仅授予令牌所需的最小权限。
>
> \2. 用访问令牌替换密码。在您的本地存储库中，使用以下命令将远程URL更改为使用访问令牌进行身份验证：
>
> \```
>
> git remote set-url origin https://<access-token>@github.com/WeC9/my_first_reposity.git
>
> \```
>
> 请将`<access-token>`替换为您的访问令牌。
>
> \3. 现在您可以尝试再次进行操作，Git应该会使用访问令牌进行身份验证，而不是使用密码。
>
> 如果您仍然遇到问题，可以尝试使用SSH密钥进行身份验证，或者查看GitHub文档以获取更多帮助。