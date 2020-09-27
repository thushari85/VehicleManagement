import React from 'react';
import { connect } from 'react-redux';

import errorBoundry from '../../ErrorBoundry';
import { getCars } from '../../actions/index';

class CarList extends React.Component {
    componentDidMount() {
        this.props.getCars();
    }

    renderCarsTable(cars) {
        return (
            <table>
                <thead>
                    <tr>
                        <th>Make</th>
                        <th>Model</th>
                        <th>Engine</th>
                        <th>Doors</th>
                        <th>Wheels</th>
                    </tr>
                </thead>
                <tbody>
                    {cars.map(car => 
                        <tr>
                            <td>{car.make}</td>
                            <td>{car.model}</td>
                            <td>{car.engine}</td>
                            <td>{car.doors}</td>
                            <td>{car.wheels}</td>
                        </tr>
                    )}
                </tbody>
            </table>
        )
    }

    render() {
        return (
            <table className='table table-striped' aria-labelledby="tabelLabel">
                <thead>
                    <tr>
                        <th scope="col">Make</th>
                        <th scope="col">Model</th>
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
    debugger;
    return { cars: Object.values(state.Cars) }
}

export default errorBoundry(connect(mapStateToProps, { getCars })(CarList));