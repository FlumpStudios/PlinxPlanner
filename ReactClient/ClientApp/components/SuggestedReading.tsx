import * as React from 'react'; 
import { Header } from 'semantic-ui-react';
 
class SuggestReading extends React.Component {
    state = { }
    render() { 
        return ( 
            <div>
                <Header as="h3">Suggested Reading and Tutorials</Header>
                <Header as="h4">.NET</Header>
                <ul>
                    <li>
                        <a href="https://docs.microsoft.com/en-us/aspnet/core/getting-started/?view=aspnetcore-2.2&tabs=windows">Getting started with .NET core 2.2</a>                        
                    </li>
                    <li>
                       <a href="https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/dependency-injection?view=aspnetcore-2.2">Dependency injection in ASP.NET Core</a>
                    </li>    
                    <li>
                        <a href="https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio">Create a web API with ASP.NET Core MVC</a>
                    </li>                              
                </ul>
                <Header as="h4">Unit testing</Header>
                <ul>
                    <li>                  
                        <a href="https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest">Unit testing C# with MSTest and .NET Core</a>          
                    </li>
                    <li>                  
                        <a href="https://github.com/Moq/moq4/wiki/Quickstart">MOQ Quickstart</a>          
                    </li>
                </ul>
                <Header as="h4">Identity server and Oauth 2</Header>
                <ul>
                    <li>
                        <a href="https://oauth.net/2/">OAuth 2.0</a> 
                    </li>
                    <li>
                        <a href="http://docs.identityserver.io/en/latest/">Welcome to IdentityServer4</a> 
                    </li>
                    <li>
                        <a href="https://github.com/skoruba/IdentityServer4.Admin">Skoruba (IdentityServer4 Admin)</a> 
                    </li>
                    <li>
                        <a href="https://www.youtube.com/watch?v=8IXIFuaHAt8">Building APIs for developers with Identity Server 4 - Ben Cull (Video)</a> 
                    </li>
                    <li>
                        <a href="https://docs.microsoft.com/en-us/aspnet/core/security/?view=aspnetcore-2.2">Overview of ASP.NET Core Security</a> 
                    </li>
       
                    </ul>
                    <Header as="h4">Swagger and Swashbuckle</Header>
                    <ul>
                        <li>
                            <a href="https://swagger.io/docs/specification/2-0/what-is-swagger/">What is Swagger? </a> 
                        </li>
                        <li>
                            <a href="https://github.com/domaindrivendev/Swashbuckle">Swashbuckle on GitHub</a> 
                        </li> 
                    </ul>
                    <Header as="h4">Client side</Header>
                    <ul>
                        <li>
                            <a href="https://reactjs.org/tutorial/tutorial.html">Intro to React</a> 
                        </li>
                        <li>
                            <a href="https://www.typescriptlang.org/docs/handbook/typescript-in-5-minutes.html">TypeScript in 5 minutes</a> 
                        </li>
                        <li>
                            <a href="https://redux.js.org/introduction/getting-started">Getting Started with Redux</a>
                        </li>
                        <li>
                            <a href="https://github.com/maxmantz/redux-oidc">Redux Oidc</a>
                        </li>
                        <li>
                            <a href="https://www.sitepoint.com/react-router-v4-complete-guide/">React Router v4: The Complete Guide</a>
                        </li>
                        <li>
                            <a href="https://www.npmjs.com/package/@casl/react">CASL React (React Permission mapping library)</a>
                        </li>
                        <li>
                            <a href="https://react.semantic-ui.com/">Semantic UI React Introduction</a>
                        </li>
                    </ul>
                    <Header as="h4">Misc</Header>
                    <ul>
                        <li>
                            <a href="https://github.com/nlog/nlog/wiki">NLog Documentation - .NET logging platform</a>
                        </li>
                        <li>
                            <a href="https://github.com/FlumpStudios/MemCacheManager">MemCacheManager - Memory cache library</a>
                        </li>
                        <li>
                            <a href="https://github.com/FlumpStudios/CryptoLib">CryptoLib Github - .NET AES library</a>
                        </li>
                        <li>
                            <a href="https://medium.com/ps-its-huuti/how-to-get-started-with-automapper-and-asp-net-core-2-ecac60ef523f">How to get started with AutoMapper and ASP.NET Core 2</a>
                        </li>
                        <li>
                            <a href="https://www.youtube.com/watch?v=o_TH-Y78tt4&t=236s">The Principles of Clean Architecture by Uncle Bob Martin</a>
                        </li>
                        <li>
                            <a href="https://hackernoon.com/solid-principles-made-easy-67b1246bcdf">SOLID Principles made easy</a>
                        </li>

                    </ul>

                
            </div>

         );
    }
}
 
export default SuggestReading;