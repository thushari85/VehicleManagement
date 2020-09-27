import carsales from '../api/carsales';
import { GET_VEHICLE_TYPES, GET_CARS, CREATE_CAR } from './types';
import history from '../history';

export const getVehicleTypes = () => {
    return async(dispatch) => {
        try {
            const response = await carsales.get('/VehicleType');

            dispatch({
                type: GET_VEHICLE_TYPES,
                payload: response.data
            });
        } catch(error) {
            console.error(error);
        }        
    };
}

export const getCars = () => {
    return async(dispatch) => {
        try {

            const response = await carsales.get('/Car');
            
            dispatch({
                type: GET_CARS,
                payload: response.data
            });
        } catch (error) {
            console.error(error);
        }
    }
}

export const addCar = (formValues) => {
    return async(dispatch) => {
        try {
            const response = await carsales.post('/Car', {...formValues});
            
            dispatch({
                type: CREATE_CAR,
                payload: response.data
            });
            history.push('/car');
        } catch(error) {
            console.error(error);
        }
        
    }
}