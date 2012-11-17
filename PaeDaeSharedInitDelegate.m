//
//  PaeDaePrizeDelegate.m
//
//  Created by Miguel Morales on 7/19/12.
//  Copyright (c) 2012 PaeDae Inc. All rights reserved.

#import "PaeDaeSharedInitDelegate.h"

@implementation PaeDaeSharedInitDelegate

static PaeDaeSharedInitDelegate *sharedDelegate = nil;

#pragma mark - static singleton access method
+ (id) sharedDelegate
{
    if (self == [PaeDaeSharedInitDelegate class] && !sharedDelegate)
    {
        sharedDelegate = [[PaeDaeSharedInitDelegate alloc] init];
    }
    
    return sharedDelegate;
}

- (void)PaeDae_Initialized
{
    NSLog(@"TESTING UNITY CALLBACK!");
    UnitySendMessage("GameObject", "UnityCallback", "This is a test!");
}

- (void)PaeDae_InitializeFailed
{
    NSLog(@"INITIALIZATION FAILED");
}

@end
