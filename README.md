# Herald.Notification

![Status](https://github.com/tcfialho/Herald.Notification/workflows/Herald.Notification/badge.svg) ![Coverage](https://codecov.io/gh/tcfialho/Herald.Notification/branch/master/graph/badge.svg) ![NuGet](https://buildstats.info/nuget/Herald.Notification)

## Overview
Herald.Notification is a set of building blocks for publish different types of "foward only" notifications.

## Installation

Herald.Notification have different packages, each handle a 3rd library message queue.

- Sns
    - Package Manager

        ```
        Install-Package Herald.Notification.Sns
        ```
    - .NET CLI
        ```
        dotnet add package Herald.Notification.Sns
        ```

- Sms
    - Package Manager

        ```
        Install-Package Herald.Notification.Sns.Sms
        ```
    - .NET CLI
        ```
        dotnet add package Herald.Notification.Sns.Sms
        ```

- Email
    - Package Manager

        ```
        Install-Package Herald.Notification.Sns.Email
        ```
    - .NET CLI
        ```
        dotnet add package Herald.Notification.Sns.Email
        ```

## Samples
- [Herald.Notification.Samples](https://github.com/tcfialho/Herald.Notification.Samples)

## HealthCheck
- [Herald.Notification.HealthCheck](https://github.com/tcfialho/Herald.Notification.HealthCheck)

## Credits

Author [**Thiago Fialho**](https://br.linkedin.com/in/thiago-fialho-139ab116)

## License

Herald.Notification is licensed under the [MIT License](LICENSE).