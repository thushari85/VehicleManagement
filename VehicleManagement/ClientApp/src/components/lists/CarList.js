import React from 'react';
import { connect } from 'react-redux';

import errorBoundry from '../../ErrorBoundry';
import { getCars } from '../../actions/index';

class CarList extends React.Component {
    componentDidMount() {
        this.props.getCars();
    }

    render() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th scope="col">Make</th>
                        <th scope="col">Model</th>
                        <th scope="col">Body Type</th>
                        <th scope="col">Engine</th>
                        <th scope="col">Doors</th>
                        <th scope="col">Wheels</th>
                    </tr>
                </thead>
                <tbody>
                    {this.props.cars.map(car => 
                        <tr>
                            <td>{car.make}</td>
                            <td>{car.model}</td>
                            <td>{car.bodyType}</td>
                            <td>{car.engine}</td>
                            <td>{car.doors}</td>
                            <td>{car.wheels}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        )
    }
}

const mapStateToProps = (state) => {
    return { cars: Object.values(state.Cars) }
}

export default errorBoundry(connect(mapStateToProps, { getCars })(CarList));