import * as React from "react";
import userManager from "../userManager";
import Can from "../permissions/Can"

import {
  Container,
  Menu,
  Image,
  Segment,
  Dropdown,
  Grid  
} from "semantic-ui-react";

import { NavLink, Link } from "react-router-dom";

interface LayoutProps {
  isConnected: boolean;
}

export default class Layout extends React.Component<LayoutProps, {}> {
  componentDidMount() {
    //Check if the user is Authenticated. If not redirect to the Identity server
    console.log(this.props);
    if (!this.props.isConnected) this.login();
  }

  logout = (event: any) => {
    event.preventDefault();
    userManager.signoutRedirect();
    userManager.removeUser();
  };

  login() {
    // pass the current path to redirect to the correct page after successfull login
    userManager.signinRedirect({
      data: { path: window.location.pathname }
    });
  }

  //Render methods
  renderMainContent = () => {
    return <Container>{this.props.children}</Container>;
  };

  renderAuthMenu() {
    return (
      <Menu stackable inverted>
        <Container>
          <Image
            as={NavLink}
            to="/"
            style={{ marginRight: "7%" }}
            src={require("../content/images/ListereLogo.png")}
          />
          <Menu.Item as={NavLink} to="/" exact>
            Home
          </Menu.Item>
          <Menu.Item as={NavLink} to="/ApiTable" exact>
            Api Demo
          </Menu.Item>
          <Dropdown item icon="cogs">
            <Dropdown.Menu>
              <Dropdown.Header>Account</Dropdown.Header>
              <Can I="NavigateTo" a="User">
                <Dropdown.Item as={Link} to="/user" text="User Info" />
              </Can>      
              <Dropdown.Item text="Logout" onClick={this.logout.bind(this)} />
            </Dropdown.Menu>
          </Dropdown>
        </Container>
      </Menu>
    );
  }

  RenderFooter = () => {
    return (
      <Segment
        inverted
        vertical
        style={{
          margin: "2em 0em 0em",
          width: "100%",
          padding: "2em 0em",
          position: "fixed",
          bottom: "0px"
        }}
      >
        <Container textAlign="center">
          <Grid divided inverted stackable />
          <h4>Listers Deal Log 2019</h4>
        </Container>
      </Segment>
    );
  };

  render() {
    //Don't render anything until user has been authenticated
    if (!this.props.isConnected)
      return <React.Fragment>Authenticating user...</React.Fragment>;

    return (
      <React.Fragment>
        {this.renderAuthMenu()}
        {this.renderMainContent()}       
      </React.Fragment>
    );
  }
}
