import { useState } from 'react';
import config from '../../config';

function CreateStudent() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [address, setAddress] = useState('');

  const handleCreateStudent = async () => {
    const response = await fetch(`${config.apiBaseUrl}/api/student`, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
      },
      body: JSON.stringify({
        FirstName:firstName,
        LastName:lastName,
        Address:address,
      }),
    });
    const data = await response.json();
    console.log(data);
  };

  return (
    <div>
      <h1>Create Student</h1>
      <div className="form-group">
        <label>First Name:</label>
        <input 
          type="text" 
          value={firstName} 
          onChange={(e) => setFirstName(e.target.value)} 
        />
      </div>
      <div className="form-group">
        <label>Last Name:</label>
        <input 
          type="text" 
          value={lastName} 
          onChange={(e) => setLastName(e.target.value)} 
        />
      </div>
      <div className="form-group">
        <label>Address:</label>
        <input 
          type="text" 
          value={address} 
          onChange={(e) => setAddress(e.target.value)} 
        />
      </div>
      <button onClick={handleCreateStudent}>Create Student</button>
    </div>
  );
}

export default CreateStudent;