import React from 'react';
import { connect } from 'react-redux';

import CarForm from './CarForm';
import errorBoundry from '../../../ErrorBoundry';
import { addCar } from '../../../actions/index';

class CarAdd extends React.Component {

    onFormSubmit = (formValues) => {
        this.props.addCar(formValues);
    }

    render() {
        return (
            <div>
                <h3 className="text-muted">Create Car</h3>
                <CarForm onSubmit={this.onFormSubmit}></CarForm>
            </div>
        )
    }
}

export default errorBoundry(connect(null, { addCar })(CarAdd));