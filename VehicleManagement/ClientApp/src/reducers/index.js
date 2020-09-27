import  { combineReducers } from 'redux';
import { reducer as formReducer } from 'redux-form';

import vehicleTypeReducer from './vehicleTypeReducer';
import carReducer from './carReducer';

export default combineReducers({
    VehicleType: vehicleTypeReducer,
    Cars: carReducer,
    form: formReducer
});