import * as Yup from 'yup'
import { useState } from 'react'
import { Icon } from '@iconify/react'
import { useFormik, Form, FormikProvider } from 'formik'
import eyeFill from '@iconify/icons-eva/eye-fill'
import eyeOffFill from '@iconify/icons-eva/eye-off-fill'
import { useNavigate } from 'react-router-dom'
// material
import { Stack, TextField, IconButton, InputAdornment } from '@mui/material'
import { LoadingButton } from '@mui/lab'

// ----------------------------------------------------------------------

export default function RegisterForm() {
  const navigate = useNavigate()
  const [showPassword, setShowPassword] = useState(false)

  const RegisterSchema = Yup.object().shape({
    // firstName: Yup.string()
    //   .min(2, 'Too Short!')
    //   .max(50, 'Too Long!')
    //   .required('First name required'),
    // lastName: Yup.string().min(2, 'Too Short!').max(50, 'Too Long!').required('Last name required'),
    email: Yup.string().email('Email must be a valid email address').required('Email is required'),
    // password: Yup.string().required('Password is required'),
    fullName: Yup.string().min(2, 'Too Short!').max(30, 'Too Long!').required('Full Name is required'),
    address: Yup.string().min(5, 'Too Short!').max(40, 'Too Long!').required('Address is required')
  })

  const formik = useFormik({
    initialValues: {
      // firstName: '',
      // lastName: '',
      email: '',
      // password: '',
      fullName: '',
      address: ''
    },
    validationSchema: RegisterSchema,
    onSubmit: (value) => {
      console.log(value)
    }
  })

  const { errors, touched, isSubmitting, getFieldProps, handleSubmit } = formik


  return (
    <FormikProvider value={formik}>
      <Form autoComplete="off" noValidate onSubmit={handleSubmit}>
        <Stack spacing={3}>
          {/* <Stack direction={{ xs: 'column', sm: 'row' }} spacing={2}>
            <TextField
              fullWidth
              label="First name"
              {...getFieldProps('firstName')}
              error={Boolean(touched.firstName && errors.firstName)}
              helperText={touched.firstName && errors.firstName}
            />

            <TextField
              fullWidth
              label="Last name"
              {...getFieldProps('lastName')}
              error={Boolean(touched.lastName && errors.lastName)}
              helperText={touched.lastName && errors.lastName}
            />
          </Stack> */}

          <TextField
            fullWidth
            label="Full name"
            {...getFieldProps('fullName')}
            error={Boolean(touched.fullName && errors.fullName)}
            helperText={touched.fullName && errors.fullName}
          />

          <TextField
            fullWidth
            autoComplete="username"
            type="email"
            label="Email address"
            {...getFieldProps('email')}
            error={Boolean(touched.email && errors.email)}
            helperText={touched.email && errors.email}
          />

          <TextField
            fullWidth
            label="Address"
            {...getFieldProps('address')}
            error={Boolean(touched.address && errors.address)}
            helperText={touched.address && errors.address}
          />

          {/* <TextField
            fullWidth
            autoComplete="current-password"
            type={showPassword ? 'text' : 'password'}
            label="Password"
            {...getFieldProps('password')}
            InputProps={{
              endAdornment: (
                <InputAdornment position="end">
                  <IconButton edge="end" onClick={() => setShowPassword((prev) => !prev)}>
                    <Icon icon={showPassword ? eyeFill : eyeOffFill} />
                  </IconButton>
                </InputAdornment>
              )
            }}
            error={Boolean(touched.password && errors.password)}
            helperText={touched.password && errors.password}
          /> */}

          <LoadingButton
            fullWidth
            size="large"
            type="submit"
            variant="contained"
            loading={isSubmitting}
          // onClick={handleSubmit}
          >
            Register
          </LoadingButton>
        </Stack>
      </Form>
    </FormikProvider>
  )
}