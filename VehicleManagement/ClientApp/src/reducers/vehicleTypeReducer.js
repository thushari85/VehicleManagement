import _ from 'lodash';

import { GET_VEHICLE_TYPES } from '../actions/types';

export default(state = [], action) => {
    switch(action.type) {
        case GET_VEHICLE_TYPES:
            return {...state, ..._.mapKeys(action.payload, 'vehicleTypeID')}
        default:
            return state;
    }
}