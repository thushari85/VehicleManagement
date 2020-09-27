import _ from 'lodash';

import { GET_CARS } from '../actions/types';

export default(state = [], action) => {
    switch(action.type) {
        case GET_CARS: 
            return {...state, ..._.mapKeys(action.payload, 'id')};
        default:
            return state;
    }
}
