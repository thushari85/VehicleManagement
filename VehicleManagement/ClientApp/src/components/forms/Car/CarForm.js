import React from 'react';
import { Field, reduxForm } from 'redux-form';

class CarForm extends React.Component {

    onFormSubmit = (formValues, props) => {
        props.onSubmit(formValues);
    }

    renderError({error, touched}) {
        if(touched && error) {
            return (
                <div className="text-danger">
                    {error}
                </div>
            )
        }
    }

    renderDropDown = ( {input, label, maxNumber} ) => {
        return(
            <div className="form-group">
                <label>{label}</label>
                <select className="form-control" {...input}>
                   {this.renderDropDownItems(maxNumber)}
                </select>
            </div>
        )
    }

    renderDropDownItems = (maxNumber) => {
        let options = [];
        for(let i=1; i < maxNumber + 1; i++) {
            options.push(<option key={i} value={i}>{i}</option>)
        }
        return options;
    }

    renderInput = ({input, label, meta}) => {
        return(
            <div className="form-group">
                <label>{label}</label>
                <input className="form-control" {...input}/>
                {this.renderError(meta)}
            </div>
        )
    }

    render() {
        return (
            <form onSubmit={this.props.handleSubmit((formValues) => this.onFormSubmit(formValues, this.props))}>
                <Field name="make" component={this.renderInput} label="Make"></Field>
                <Field name="model" component={this.renderInput} label="Model"></Field>
                <Field name="engine" component={this.renderInput} label="Engine"></Field>
                <Field name="doors" component={this.renderDropDown} maxNumber={5} label="Doors" parse={(val) => parseInt(val)}></Field>
                <Field name="wheels" component={this.renderDropDown} maxNumber={10} label="Wheels" parse={(val) => parseInt(val)}></Field>
                <Field name="bodyType" component={this.renderInput} label="Body Type"></Field>
                <button className="btn btn-primary">Submit</button>
            </form>
        )
    }
}

const validate = (formValues) => {
    const errors = {};
    if(!formValues.make) {
        errors.make = "Make is required";
    }

    if(!formValues.model) {
        errors.model = "Model is required";
    }

    if(!formValues.engine) {
        errors.engine = "Engine is required";
    }

    if(!formValues.bodyType) {
        errors.bodyType = "Body Type is required";
    }

    return errors;
}

export default reduxForm({
    form: 'carForm',
    validate: validate
})(CarForm);
