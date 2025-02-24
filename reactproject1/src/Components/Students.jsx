import { useEffect, useState } from 'react';
import config from '../../config';
import StudentTable from './StudentTable';

function Students() {
  const [students, setStudents] = useState([]);

  const fetchStudents = async () => {
    try {
      const response = await fetch(`${config.apiBaseUrl}/api/student`);
      const data = await response.json();
      if (response.ok) {
        setStudents(data);
      } else {
        console.error('Failed to fetch students:', data.message);
      }
    } catch (error) {
      console.error('Error fetching students:', error);
    }
  };

  useEffect(() => {
    fetchStudents();
  }, []);
  return (
    <div>
      <h1>Student List</h1>
      <button onClick={fetchStudents}>Refresh</button>
      <StudentTable students={students} />
    </div>
  );
}

export default Students;