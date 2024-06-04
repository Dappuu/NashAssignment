// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
import { getStorage } from 'firebase/storage';

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyA8RAcOeR6RsJcw4vi9zygUNQTxk6fLr8U",
  authDomain: "nash-assigment.firebaseapp.com",
  projectId: "nash-assigment",
  storageBucket: "nash-assigment.appspot.com",
  messagingSenderId: "4764941873",
  appId: "1:4764941873:web:02045cb63e5c023028df10",
  measurementId: "G-M6GH81DF9Q"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);
export const storage = getStorage(app);