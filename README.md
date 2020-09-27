# VehicleManagement

SETUP
- Update-Database command needs to be run on Package Manager Console to setup the Database

NOTES:

- The Services Layer could have been removed and the repository directly used in the controllers to access the data which would have made the solution simple. However, I decided to separate layers to allow for loosely coupled layers. With this approach as more functionality gets added in the business logic can be applied in the Services layer and it will have no impact on the Repository. 
- IVehicleRepositoryBase was created to contain the basic repository functions required by all Vehicle types. Any vehicle type specific functions can be added to that vehicle types interface eg: ICarRepository 

Future Improvements:
- Authorization and Access Control 
- Greater unit test coverage	
- Integration Tests
- Improved logging to log request / response information
- Currently the Car, Vehicle and VehicleType classes in Model folder are used by all 3 layers (Repository, Services and Controller) for simplicity. Hence any changes to these classes will affect the database. Therefore, it would be better to create a different set of classes to be used by the Services and Controllers 
