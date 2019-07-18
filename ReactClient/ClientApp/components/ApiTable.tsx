import * as React from "react";
import axios from "axios";
import {
  Table,
  Header,
  Loader
} from "semantic-ui-react";
import customerModel from "../models/customerModel";
import Can from "../permissions/Can";

const styles = {
  inputBoxes: {
    padding: "8px",
    display: "block"
  }
};

class ApiTable extends React.Component {
  state = { result: [new customerModel()], resultsLoaded: false };

  componentDidMount() {
    axios
      .get("http://localhost:5200/api/v1/Customer")
      .then((response: any) => {
        this.setState({ result: response.data, resultsLoaded: true });
        console.log(this.state.result);
      })
      .catch(error => {
        const { status, statusText } = error.response;
        this.setState({ result: `${status}: ${statusText}` });
      });
  }

  renderSpinner() {
    return <Loader active size="massive" />;
  }

  renderTable() {
    return (
      <React.Fragment>
        <Header as="h3" color="grey">
          Search Results
        </Header>
        <Table>
          <Table.Header>
            <Table.Row>
              <Table.HeaderCell>Customer ID</Table.HeaderCell>
              <Table.HeaderCell>Customer Name</Table.HeaderCell>
              <Table.HeaderCell>vehicle Type</Table.HeaderCell>
              <Table.HeaderCell>VIN</Table.HeaderCell>
              <Table.HeaderCell>VRN</Table.HeaderCell>
              <Table.HeaderCell>Postcode</Table.HeaderCell>
              <Table.HeaderCell>Last Updated</Table.HeaderCell>
              <Table.HeaderCell>Delivery Date</Table.HeaderCell>
            </Table.Row>
            {this.renderResults()}
          </Table.Header>
          <Table.Body />
        </Table>
      </React.Fragment>
    );
  }

  renderResults() {
    const nullContentText: string = "Not available";
    return (
      <React.Fragment>
        <Can I="View" a="CustomerTable">
          {this.state.result.map((x, k) => (
            <Table.Row key={k}>
              <Table.Cell>{x.customerId}</Table.Cell>
              <Table.Cell>{`${x.title} ${x.firstName} ${
                x.surname
              }`}</Table.Cell>
              <Table.Cell>
                {x.vehicle[0] === undefined
                  ? nullContentText
                  : x.vehicle[0].vehicleType === null
                  ? nullContentText
                  : x.vehicle[0].vehicleType}
              </Table.Cell>
              <Table.Cell>
                {x.vehicle[0] === undefined
                  ? nullContentText
                  : x.vehicle[0].vin === null
                  ? nullContentText
                  : x.vehicle[0].vin}
              </Table.Cell>
              <Table.Cell>
                {x.vehicle[0] === undefined
                  ? nullContentText
                  : x.vehicle[0].vehicleRegistration === null
                  ? nullContentText
                  : x.vehicle[0].vehicleRegistration}
              </Table.Cell>
              <Table.Cell>
                {x.customerAddress[0] === undefined
                  ? nullContentText
                  : x.customerAddress[0].postcode === null
                  ? nullContentText
                  : x.customerAddress[0].postcode}
              </Table.Cell>
              <Table.Cell>
                {x.lastUpdateDate == null ? nullContentText : x.lastUpdateDate}
              </Table.Cell>
              <Table.Cell>
                {x.vehicle[0] === undefined
                  ? nullContentText
                  : x.vehicle[0].deliveryDate === null
                  ? nullContentText
                  : x.vehicle[0].deliveryDate}
              </Table.Cell>
            </Table.Row>
          ))}
        </Can>
      </React.Fragment>
    );
  }

  render() {
    return (
      <React.Fragment>
        {this.state.resultsLoaded ? this.renderTable() : this.renderSpinner()}
      </React.Fragment>
    );
  }
}

export default ApiTable;
