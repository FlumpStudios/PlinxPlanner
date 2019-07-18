import * as React from 'react'; 
import {
    Header,
    Image
  } from "semantic-ui-react"; 

class DataPipeLine extends React.Component {
    state = {}
    render() { 
        return ( 
            <div>
                <Header as='h3'>Data Pipeline</Header>                
                <p>
                  Below is a basic chart depicting the average flow of a requst from a client. This is a high level overview and does not include forks for errors.
                </p>
                <Image            
           
            src={require("../content/images/Flow.png")}
          /> 
            </div>
         );
    }
}
 
export default DataPipeLine;