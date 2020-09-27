import React from 'react';

const errorBoundry = (component) => {
    return class ErrorBoundry extends React.Component {
        state = {
            hasError: false
        }

        static getDerivedStateFromError(error) {
            return { hasError: true };
        }
    
        componentDidCatch(error) {
            console.error(error);
        }
    
        render() {
            if(this.state.hasError) {
                return (
                    <div>
                        <h3>Something went wrong</h3>
                        <div>{this.state.error}</div>
                    </div>
                )
            }
            return React.createElement(component, this.props);
        }
    }
};

export default errorBoundry;

