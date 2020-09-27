import React from 'react';
import { connect } from 'react-redux';

import history from '../history';
import { getVehicleTypes } from '../actions';
import errorBoundry from '../ErrorBoundry';

class Home extends React.Component {
  static displayName = Home.name;

  state = {
    selectedVehicleType: null
  }

  componentDidMount() {
    this.props.getVehicleTypes();
  }

  renderVehicleTypes() {
    return (
      this.props.VehicleType.map(vehicle => {
        return <option key={vehicle.id} value={vehicle.type}>{vehicle.type}</option>
      })
    );
  }

  render () {
    return (
      <div>
        <select className="custom-select" id="VehicleType" onChange={(event) => {history.push(`/${event.target.value.toLowerCase()}/new`)}}>
          <option value={null}>Choose Type</option>
          {this.renderVehicleTypes()}
        </select>
      </div>
    );
  }
}

const mapStateToProps = (state) => {
  return {
    VehicleType: Object.values(state.VehicleType)
  }
}

export default errorBoundry(connect(mapStateToProps, { getVehicleTypes })(Home));
