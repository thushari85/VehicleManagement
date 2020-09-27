# VehicleManagement

- Authorization and Access Control was considered to be out of scope for this project

- There is room for better coverage on unit tests	

- The Services Layer could have been removed and the repository directly used in the controllers to access the data which would have made the solution simple. However, I decided to separate layers to allow for better separation of layers as more functionality is added on in the future. With this approach the business logic can be applied in the Services layer and it will have no impact on the Repository. Which prevents tight coupling between the layers.
