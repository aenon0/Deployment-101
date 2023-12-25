'use client'

import * as z from 'zod'
import { zodResolver } from '@hookform/resolvers/zod'
import { useForm } from 'react-hook-form'
import Image from 'next/image'
import Link from 'next/link'
import { Button } from '@/components/ui/button'
import {
  Form,
  FormControl,
  FormDescription,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from '@/components/ui/form'
import { Input } from '@/components/ui/input'

const formSchema = z.object({
  firstName: z.string(),
  lastName: z.string(),
  email: z.string().email({ message: 'Invalid email address' }),
  password: z
    .string()
    .min(8, { message: 'Password must be at least 8 characters long' }),
})



const SigninPage = () => {

  const form = useForm<z.infer<typeof formSchema>>({
    resolver: zodResolver(formSchema),
    defaultValues: {
      email: '',
      password: '',
    },
  })
  
  function onSubmit(values: z.infer<typeof formSchema>) {
    console.log(values)
  }

  return (
    <section className='flex justify-around mx-16 my-16'>
      <div>
        <Image
          src='/auth.png'
          alt='Sign in'
          width={500}
          height={500}
        />
      </div>
      <div className='flex flex-col w-1/2 p-12'>
        <Form {...form}>
          <form onSubmit={form.handleSubmit(onSubmit)} className='space-y-8'></form>
          <FormField
            control={form.control}
            name='firstName'
            render={({ field }) => (
              <FormItem className='mb-4'>
                <FormLabel>First Name</FormLabel>
                <FormControl>
                  <Input placeholder='First Name' {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name='lastName'
            render={({ field }) => (
              <FormItem className='mb-4'>
                <FormLabel>Last Name</FormLabel>
                <FormControl>
                  <Input placeholder='Last Name' {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name='email'
            render={({ field }) => (
              <FormItem className='mb-4'>
                <FormLabel>Email</FormLabel>
                <FormControl>
                  <Input placeholder='Email' {...field} />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <p className='mt-4 text-sm text-gray-500 self-end'>Forgot password ?</p>
          <Button className='mt-8' type='submit'>Sign in</Button>
          <p className='mt-4 text-sm text-gray-500 self-center'>
            Do you have an account ? 
            {' '}
            <Link className='font-bold' href='/signup'>
              Sign up
            </Link>
          </p>
        </Form>
      </div>
    </section>
  )
}

export default SigninPage
