import axios from 'axios';

const API_URL = 'https://localhost:7083/api/User/';

class AuthService {
  login(user) {
    return axios
      .post(API_URL + 'Login', {
        username: user.username,
        password: user.password
      })
      .then(response => {
        if (response.data.isSuccess) {
          localStorage.setItem('user', JSON.stringify(response.data.payload.jwt));
        }

        return response.data;
      });
  }

  logout() {
    localStorage.removeItem('user');
  }

  register(user) {
    return axios.post(API_URL + 'signup', {
      username: user.username,
      email: user.email,
      password: user.password
    });
  }
}

export default new AuthService();
