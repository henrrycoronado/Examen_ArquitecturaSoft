import React from 'react';

const Form = () => {
  const handleSubmit = (e) => {
    e.preventDefault();
    // Add your form submission logic here
    console.log('Form submitted');
  };

  return (
    <div className="form-container">
      <form onSubmit={handleSubmit}>
        <div className="form-group">
          <label htmlFor="name">Name:</label>
          <input
            type="text"
            id="name"
            name="name"
            className="form-control"
          />
        </div>
        <button 
          type="submit"
          className="submit-button"
        >
          Submit
        </button>
      </form>
    </div>
  );
};

export default Form;
